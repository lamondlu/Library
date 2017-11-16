using System;
using System.Collections.Generic;
using BookingLibrary.Domain.Core;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Reflection;
using BookingLibrary.Infrastructure.InjectionFramework;
using BookingLibrary.Domain.Core.DataAccessor;
using BookingLibrary.Domain.Core.Messaging;

namespace BookingLibrary.Infrastructure.EventStorage.SQLServer
{
    public class SQLServerEventStorage : IEventStorage
    {
        private readonly IEventPublisher _eventPublisher = null;

        public SQLServerEventStorage()
        {
            _eventPublisher = InjectContainer.GetInstance<IEventPublisher>();
        }

        public IEnumerable<DomainEvent> GetEvents(Guid aggregateId)
        {
            var sql = "select * from Events where AggregateRootId=@id";

            var dataTable = DbHelper.ExecuteDataTable(sql,
                new SqlParameter
                {
                    ParameterName = "@id",
                    SqlDbType = System.Data.SqlDbType.UniqueIdentifier,
                    Value = aggregateId
                });

            var result = new List<DomainEvent>();
            foreach (DataRow row in dataTable.Rows)
            {
                var eventName = row["EventName"].ToString();
                JsonSerializerSettings setting = new JsonSerializerSettings();
                setting.MaxDepth = 10;

                var type = Assembly.Load(row["AssemblyName"].ToString()).GetType(eventName);
                var item = (DomainEvent)JsonConvert.DeserializeObject(row["Content"].ToString(), type, setting);
                result.Add(item);
            }

            return result;
        }
        public void Save(AggregateRoot aggregate, Guid commandUniqueId)
        {
            using (var connection = new SqlConnection(InjectContainer.GetInstance<IEventDBConnectionStringProvider>().ConnectionString))
            {
                connection.Open();

                using (var tran = connection.BeginTransaction())
                {

                    var uncommittedChanges = aggregate.GetUncommittedChanges();
                    var currentIndex = 0;

                    try
                    {
                        var version = aggregate.Version;

                        foreach (var @event in uncommittedChanges)
                        {

                            version++;
                            @event.Version = version;
                            @event.CommandUniqueId = commandUniqueId;

                            var sql = "insert into Events(AggregateRootId, Version, [EventName], [Content], OccurredOn,AssemblyName) values(@id, @version,@eventName,@content,@occurredOn,@assemblyName)";
                            var command = connection.CreateCommand();
                            command.CommandText = sql;
                            command.CommandType = CommandType.Text;
                            command.Transaction = tran;

                            command.Parameters.Add(new SqlParameter { ParameterName = "@id", SqlDbType = SqlDbType.UniqueIdentifier, Value = @event.AggregateId });
                            command.Parameters.Add(new SqlParameter { ParameterName = "@version", SqlDbType = SqlDbType.Int, Value = @event.Version });
                            command.Parameters.Add(new SqlParameter { ParameterName = "@eventName", SqlDbType = SqlDbType.NVarChar, Value = @event.GetType().FullName });
                            command.Parameters.Add(new SqlParameter { ParameterName = "@content", SqlDbType = SqlDbType.NVarChar, Value = JsonConvert.SerializeObject(@event) });
                            command.Parameters.Add(new SqlParameter { ParameterName = "@occurredOn", SqlDbType = SqlDbType.DateTime2, Value = @event.OccurredOn });
                            command.Parameters.Add(new SqlParameter { ParameterName = "@assemblyName", SqlDbType = SqlDbType.NVarChar, Value = @event.GetType().Assembly.GetName().Name });

                            command.ExecuteNonQuery();

                            currentIndex++;
                        }

                        foreach (var @event in uncommittedChanges)
                        {

                            var desEvent = Converter.ChangeTo(@event, @event.GetType());
                            _eventPublisher.Publish(desEvent);
                        }

                        tran.Commit();
                    }
                    catch
                    {

                    }
                }
            }
        }
    }
}
