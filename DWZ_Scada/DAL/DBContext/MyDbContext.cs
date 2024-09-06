using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoTF;
using DWZ.DAL.Entity;
using DWZ_Scada.DAL.Entity;
using Microsoft.Extensions.Configuration;

namespace DWZ_Scada.DAL.DBContext
{
    public class MyDbContext : DbContext
    {
        /*       public MyDbContext(DbContextOptions<MyDbContext> options)
               : base(options)
               {

               }*/

        public DbSet<OpUser> OpUsers { get; set; }

        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .Build();
            base.OnConfiguring(optionsBuilder);
            //string connStr = $"Data Source=127.0.0.1;Initial Catalog=ScadaBase;User Id=sa;Password=123123;Trusted_Connection=True;Encrypt=false;";
            //string connectionStr = DbConfigManager.ConnectionStr;
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
