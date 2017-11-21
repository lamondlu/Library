using Library.Infrastructure.Core;
using System;
using Library.Infrastructure.DataPersistence.Core.SQLServer;
using Library.Infrastructure.Core.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Library.Infrasturcture.Logger.SQLServer
{
    public class Logger : ILogger
    {
        private ILogDBConnectionStringProvider _logDBConnectionStringProvider = null;

        public Logger(ILogDBConnectionStringProvider logDBConnectionStringProvider)
        {
            _logDBConnectionStringProvider = logDBConnectionStringProvider;
        }

        public void Error(Guid commandUniqueId, string commandName, string eventName, string message, string data)
        {
            Command(commandUniqueId, commandName, eventName, message, false, LogType.Error, data);
        }

        public void Command(Guid commandUniqueId, string commandName, string eventName, string message, bool isSuccess, LogType logType, string data)
        {
            var dbHelper = new DbHelper(_logDBConnectionStringProvider.ConnectionString);
            var sql = "INSERT INTO Logs(Id, LogType, CommandName, CommandUniqueId, EventName, IsSuccess, Message, CreatedOn, Data) VALUES(@id, @logType, @commandName, @commandUniqueId, @eventName, @isSuccess, @message, @createdOn, @data)";

            dbHelper.ExecuteNonQuery(sql, new List<SqlParameter>{
                new SqlParameter{ ParameterName = "@id", SqlDbType = SqlDbType.UniqueIdentifier, Value= Guid.NewGuid()},
                new SqlParameter{ ParameterName = "@logType", SqlDbType = SqlDbType.Int, Value= Convert.ToInt32(logType)},
                new SqlParameter{ ParameterName = "@commandName", SqlDbType = SqlDbType.NVarChar, Value= commandName},
                new SqlParameter{ ParameterName = "@commandUniqueId", SqlDbType = SqlDbType.UniqueIdentifier, Value= commandUniqueId},
                new SqlParameter{ ParameterName = "@eventName", SqlDbType = SqlDbType.NVarChar, Value= eventName},
                new SqlParameter{ ParameterName = "@isSuccess", SqlDbType = SqlDbType.Bit, Value= isSuccess},
                new SqlParameter{ ParameterName = "@message", SqlDbType = SqlDbType.NVarChar, Value= message},
                new SqlParameter{ ParameterName = "@createdOn", SqlDbType = SqlDbType.DateTime2, Value= DateTime.Now},
                new SqlParameter{ ParameterName = "@data", SqlDbType = SqlDbType.NVarChar, Value= data}
            }.ToArray());
        }

        public void Info(Guid commandUniqueId, string commandName, string eventName, string message, string data)
        {
            Command(commandUniqueId, commandName, eventName, message, true, LogType.Info, data);
        }

        public void Success(Guid commandUnqiueId, string commandName, string eventName, string message, string data)
        {
            Command(commandUnqiueId, commandName, eventName, message, true, LogType.Info, data);
        }
    }
}
