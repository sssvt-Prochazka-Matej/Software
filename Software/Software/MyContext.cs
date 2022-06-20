using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software
{
    public class MyContext : DbContext
    {

        public DbSet<Software> tb_Software { get; set; }

        public DbSet<License> tb_License { get; set; }

        //private readonly string connectionString;

        public MyContext()
        {
            var builder = new ConfigurationBuilder();
            //.AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();
            //_connectionString = ConfigurationManager;
            //_connectionString = config["ConnectionStrings:DBLocal"];
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = localhost; Database = DbSoftware; Trusted_Connection = True; MultipleActiveResultSets = true");
        }




    }
}
