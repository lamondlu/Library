using System;
using BookingLibrary.Service.Identity.Domain;
using BookingLibrary.Domain.Core;
using BookingLibrary.Domain.Core.DataAccessor;
using System.Data;
using System.Data.SqlClient;

namespace BookingLibrary.Infrastructure.DataPersistence.SQLServer
{
    public class IdentityReportDataAccessor : IIdentityReportDataAccessor
    {
        private IReadConnectionStringProvider _readConnectionStringProvider = null;
        private IWriteConnectionStringProvider _writeConnectionStringProvider = null;

        public IdentityReportDataAccessor(IReadConnectionStringProvider readConnectionStringProvider, IWriteConnectionStringProvider writeConnectionStringProvider)
        {
            _readConnectionStringProvider = readConnectionStringProvider;
            _writeConnectionStringProvider = writeConnectionStringProvider;
        }

        public void AddAdministrator(Administrator administrator)
        {
            using (var connection = new SqlConnection(_writeConnectionStringProvider.ConnectionString))
            {
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var sqlAddPerson = "insert into Person(PersonId, FirstName, LastName, MiddleName) values(@personId, @firstName, @lastName, @middleName)";
                        SqlHelper.ExecuteNonQuery(tran,
                            CommandType.Text,
                            sqlAddPerson,
                            new SqlParameter { SqlDbType = SqlDbType.UniqueIdentifier, ParameterName = "@personId", Value = administrator.PersonId },
                            new SqlParameter { SqlDbType = SqlDbType.NVarChar, ParameterName = "@firstName", Value = administrator.Name.FirstName },
                            new SqlParameter { SqlDbType = SqlDbType.NVarChar, ParameterName = "@lastName", Value = administrator.Name.LastName },
                            new SqlParameter { SqlDbType = SqlDbType.NVarChar, ParameterName = "@lastName", Value = administrator.Name.MiddleName }
                            );

                            var sqlAddUser = "insert into User(PersonId, Role, UserName, Password) values(@personId, @role, @userName, @password)";
                        SqlHelper.ExecuteNonQuery(tran,
                            CommandType.Text,
                            sqlAddUser,
                            new SqlParameter { SqlDbType = SqlDbType.UniqueIdentifier, ParameterName = "@personId", Value = administrator.PersonId },
                            new SqlParameter { SqlDbType = SqlDbType.NVarChar, ParameterName = "@role", Value = administrator.UserPrincipal.Role },
                            new SqlParameter { SqlDbType = SqlDbType.NVarChar, ParameterName = "@userName", Value = administrator.UserPrincipal.UserName },
                            new SqlParameter { SqlDbType = SqlDbType.NVarChar, ParameterName = "@password", Value = administrator.UserPrincipal.Password }
                            );

                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                    }
                }
            }
        }

        public void AddUser(User user)
        {
            using (var connection = new SqlConnection(_writeConnectionStringProvider.ConnectionString))
            {
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var sqlAddPerson = "insert into Person(PersonId, FirstName, LastName, MiddleName) values(@personId, @firstName, @lastName, @middleName)";
                        SqlHelper.ExecuteNonQuery(tran,
                            CommandType.Text,
                            sqlAddPerson,
                            new SqlParameter { SqlDbType = SqlDbType.UniqueIdentifier, ParameterName = "@personId", Value = user.PersonId },
                            new SqlParameter { SqlDbType = SqlDbType.NVarChar, ParameterName = "@firstName", Value = user.Name.FirstName },
                            new SqlParameter { SqlDbType = SqlDbType.NVarChar, ParameterName = "@lastName", Value = user.Name.LastName },
                            new SqlParameter { SqlDbType = SqlDbType.NVarChar, ParameterName = "@lastName", Value = user.Name.MiddleName }
                            );

                            var sqlAddUser = "insert into User(PersonId, Role, UserName, Password) values(@personId, @role, @userName, @password)";
                        SqlHelper.ExecuteNonQuery(tran,
                            CommandType.Text,
                            sqlAddUser,
                            new SqlParameter { SqlDbType = SqlDbType.UniqueIdentifier, ParameterName = "@personId", Value = user.PersonId },
                            new SqlParameter { SqlDbType = SqlDbType.NVarChar, ParameterName = "@role", Value = user.UserPrincipal.Role },
                            new SqlParameter { SqlDbType = SqlDbType.NVarChar, ParameterName = "@userName", Value = user.UserPrincipal.UserName },
                            new SqlParameter { SqlDbType = SqlDbType.NVarChar, ParameterName = "@password", Value = user.UserPrincipal.Password }
                            );

                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                    }
                }
            }
        }
    }
}
