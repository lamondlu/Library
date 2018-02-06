using Library.Infrastructure.DataPersistence.Core.SQLServer;
using Library.Infrastructure.DataPersistence.Identity.SQLServer.Extensions;
using Library.Service.Identity.Domain;
using Library.Service.Identity.Domain.DataAccessors;
using Library.Service.Identity.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Infrastructure.DataPersistence.Identity.SQLServer
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
			var sql = "SELECT TOP 1 * FROM dbo.[User] WHERE UserName = @userName and Password = @password";

			var dbHelper = new DbHelper(_readDBConnectionStringProvider.ConnectionString);

			var dt = dbHelper.ExecuteDataTable(sql, new List<SqlParameter>{
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
				}}.ToArray());

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

		public List<CustomerListViewModel> GetCustomerList()
		{
			var dbHelper = new DbHelper(_readDBConnectionStringProvider.ConnectionString);
			var sql = "SELECT * FROM dbo.[User] AS u INNER JOIN dbo.[Person] p on u.PersonId = p.PersonId WHERE u.Role = 'Customer'";

			return dbHelper.ExecuteDataTable(sql).ConvertToCustomerListView();
		}

		public CustomerListViewModel GetCustomerSingleListViewModel(Guid personId)
		{
			var dbHelper = new DbHelper(_readDBConnectionStringProvider.ConnectionString);
			var sql = "SELECT * FROM dbo.[User] AS u INNER JOIN dbo.[Person] p on u.PersonId = p.PersonId WHERE u.Role = 'Customer' and u.PersonId=@personId";

			return dbHelper.ExecuteDataTable(sql, new SqlParameter { ParameterName = "@personId", SqlDbType = SqlDbType.UniqueIdentifier, Value = personId }).ConvertToCustomerListView().FirstOrDefault();
		}

		public IdentityDetailsViewModel GetAccountDetails(Guid accountId)
		{
			var dbHelper = new DbHelper(_readDBConnectionStringProvider.ConnectionString);
			var sql = "SELECT TOP 1 p.* FROM dbo.[User] AS u INNER JOIN dbo.[Person] p on u.PersonId = p.PersonId WHERE u.PersonId=@personId";

			var dt = dbHelper.ExecuteDataTable(sql, new List<SqlParameter>{
				new SqlParameter
				{
					ParameterName = "@personId",
					SqlDbType = SqlDbType.UniqueIdentifier,
					Value = accountId
				}}.ToArray());

			if (dt.Rows.Count == 1)
			{
				return new IdentityDetailsViewModel
				{
					AccountId = Guid.Parse(dt.Rows[0]["PersonId"].ToString()),
					FirstName = dt.Rows[0]["FirstName"]?.ToString(),
					LastName = dt.Rows[0]["LastName"]?.ToString(),
					MiddleName = dt.Rows[0]["MiddleName"]?.ToString()
				};
			}

			return null;
		}

		public void CreateUser(Guid personId, string userName, string password, string firstName, string lastName, string middleName)
		{
			_commands.Add("INSERT INTO dbo.[User](PersonId, Role, UserName, Password) VALUES(@personId, @role, @userName, @password)", new List<SqlParameter>
			{
				new SqlParameter{ ParameterName = "@personId", SqlDbType = SqlDbType.UniqueIdentifier, Value = personId },
				 new SqlParameter{ ParameterName = "@role", SqlDbType = SqlDbType.NVarChar, Value = "Customer" },
				 new SqlParameter{ ParameterName = "@userName", SqlDbType = SqlDbType.NVarChar, Value = userName },
				 new SqlParameter{ ParameterName = "@password", SqlDbType = SqlDbType.NVarChar, Value = password}
			});

			_commands.Add("INSERT INTO dbo.[Person](PersonId, FirstName, MiddleName, LastName) VALUES(@personId, @firstName, @middleName, @lastName)", new List<SqlParameter> {
				new SqlParameter{ ParameterName = "@personId", SqlDbType = SqlDbType.UniqueIdentifier, Value = personId },
				 new SqlParameter{ ParameterName = "@firstName", SqlDbType = SqlDbType.NVarChar, Value =firstName },
				 new SqlParameter{ ParameterName = "@middleName", SqlDbType = SqlDbType.NVarChar, Value = middleName },
				 new SqlParameter{ ParameterName = "@lastName", SqlDbType = SqlDbType.NVarChar, Value = lastName}
			});
		}

		public void Commit()
		{
			var dbHelper = new DbHelper(_writeDBConnectionStringProvider.ConnectionString);
			dbHelper.ExecuteNoQuery(_commands);
			_commands.Clear();
		}

		public Task CommitAsync()
		{
			return Task.Factory.StartNew(() =>
			{
				Commit();
			});
		}
	}
}