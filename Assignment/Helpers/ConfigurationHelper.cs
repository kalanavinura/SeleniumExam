using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Helpers
{
    public class ConfigurationHelper
    {
        public static IConfiguration LoadConfiguration()
        { 
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public static string browser => LoadConfiguration()["browser"];

        public static string baseUrl => LoadConfiguration()["baseUrl"];

        public static string userName => LoadConfiguration()["userName"];

        public static string password => LoadConfiguration()["password"];
    }
}
