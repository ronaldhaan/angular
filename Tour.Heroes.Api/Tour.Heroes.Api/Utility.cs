using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Tour.Heroes.Api
{
    public static class Utility
    {
        public static string GetConnectionString(string connectionStringName)
        {
            if(string.IsNullOrEmpty(connectionStringName))
            {
                throw new ArgumentNullException("connectionStringName");
            }

            IConfigurationRoot configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json")
             .Build();

            return configuration.GetConnectionString(connectionStringName);
        }
    
    }
}
