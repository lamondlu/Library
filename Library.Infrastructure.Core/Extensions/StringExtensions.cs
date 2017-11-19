using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Core.Extensions
{
    public static class StringExtensions
    {
        public static string SafeConvertToString(this object source, string defaultString = "")
        {
            if (source == null)
            {
                return defaultString;
            }
            else
            {
                return source.ToString();
            }
        }
    }
}
