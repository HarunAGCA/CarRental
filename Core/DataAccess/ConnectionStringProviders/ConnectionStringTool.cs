using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataAccess.ConnectionStringProviders
{
    public class ConnectionStringTool
    {

        public static string GetConnectionString(string environmentVariableName)
        {
            var connectionString = Environment.GetEnvironmentVariable(environmentVariableName);

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("There is no valid connection string environment variable");
            }

            return connectionString;
        }

        public static string GetConnectionStringFromHerokuContainer()
        {
            string connectionUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

            var databaseUri = new Uri(connectionUrl);

            string db = databaseUri.LocalPath.TrimStart('/');
            string[] userInfo = databaseUri.UserInfo.Split(':', (char)StringSplitOptions.RemoveEmptyEntries);

            return $"User ID={userInfo[0]};Password={userInfo[1]};Host={databaseUri.Host};Port={databaseUri.Port};Database={db};Pooling=true;SSL Mode=Require;Trust Server Certificate=True;";

        }

        public static string GetConnectionStringDevelopment()
        {
            return @"Server=127.0.0.1; port=5432;Database=CarRental; user id=postgres;password=postgres;";
        }
    }
}
    