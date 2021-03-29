using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Extensions
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            var scope = host.Services.CreateScope();

            using (var dbContext = new CarRentalContext())
            {
                try
                {
                    dbContext.Database.Migrate();
                }
                catch (Exception)
                {
                    throw;
                } 
            }

            return host;
            
        }
    }
}
