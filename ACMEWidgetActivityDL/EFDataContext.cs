using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACMEWidgetActivityDL
{
    public class EFDataContext: DbContext
    {
        public DbSet<Employees> Employees { get; set; }

        public static void SetConnectionString(string connectionString)
        {
                ConnectionString = connectionString;       

        }       
 

        private static string ConnectionString { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);         
        }
    }
}
