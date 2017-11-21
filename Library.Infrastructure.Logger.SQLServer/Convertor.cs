using Library.Infrastructure.Core.Models;
using Library.Infrastructure.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace Library.Infrastructure.Logger.SQLServer
{
    public static class Convertor
    {
        public static List<CommandLogModel> ConvertTo(this DataTable dt)
        {
            return dt.Rows.Cast<DataRow>().Select(ConvertTo).ToList();
        }

        public static CommandLogModel ConvertTo(this DataRow dr)
        {
            if (dr == null)
            {
                return null;
            }
            else
            {
                return new CommandLogModel
                {
                    CommandName = dr["CommandName"].SafeConvertToString(),
                    CommandUniqueId = Guid.Parse(dr["CommandUniqueId"].SafeConvertToString()),
                    Data = dr["Data"].SafeConvertToString(),
                    EventName = dr["EventName"].SafeConvertToString(),
                    Id = Guid.Parse(dr["Id"].SafeConvertToString()),
                    IsSuccess = Convert.ToBoolean(dr["IsSuccess"]),
                    LogType = (LogType)Enum.Parse(typeof(LogType), dr["LogType"].SafeConvertToString()),
                    Message = dr["Message"].SafeConvertToString()
                };
            }
        }

    }
}
