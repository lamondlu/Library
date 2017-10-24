using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BookingLibrary.Service.Identity.Domain.DataAccessors;
using BookingLibrary.Service.Identity.Domain.ViewModels;

namespace BookingLibrary.Infrastructure.DataPersistence.Identity.SQLServer
{
    public class IdentityReportDataAccessor : IIdentityReportDataAccessor
    {
        private IIdentityReadDBConnectionStringProvider _readDBConnectionStringProvider = null;
        private IIdentityWriteDBConnectionStringProvider _writeDBConnectionStringProvider = null;

        private Dictionary<string, List<SqlParameter>> _commands = null;

        public IdentityReportDataAccessor(IIdentityReadDBConnectionStringProvider readDBConnectionStringProvider, IIdentityWriteDBConnectionStringProvider writeDBConnectionStringProvider)
        {
            _readDBConnectionStringProvider = readDBConnectionStringProvider;
            _writeDBConnectionStringProvider = writeDBConnectionStringProvider;
            _commands = new Dictionary<string, List<SqlParameter>>();
        }

        public IdentityViewModel GetIdentity(string userName, string hashedPassword)
        {
            var sql = "SELECT TOP 1 * FROM dbo.User WHERE UserName = @userName and Password = @password";

            var dbHelper = new DbHelper(_readDBConnectionStringProvider.ConnectionString);

            var dt = dbHelper.ExecuteDataTable(sql,
                new SqlParameter
                {
                    ParameterName = "@userName",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = userName
                }, new SqlParameter
                {
                    ParameterName = "@password",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = hashedPassword
                });

            if (dt.Rows.Count == 1)
            {
                return new IdentityViewModel
                {
                    UserId = Guid.Parse(dt.Rows[0]["PersonId"].ToString()),
                    Role = dt.Rows[0]["Role"].ToString()
                };
            }

            return null;
        }
    }
}
