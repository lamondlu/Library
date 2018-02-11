using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Library.CoreUI
{
    public class ConfigurationManager
    {
        private static IConfigurationRoot _configuration = null;

        static ConfigurationManager()
        {
            var builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
        }

        public static string GetValue(string key)
        {
            return _configuration[key];
        }
    }
}
