using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ScadaBase.DAL.Entity;
using ScadaBase.DAL.Interceptor;

namespace ScadaBase.DAL.DBContext
{
    public class MyDbContext : DbContext
    {
        /*       public MyDbContext(DbContextOptions<MyDbContext> options)
               : base(options)
               {

               }*/

        public DbSet<OpUser> OpUsers { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<DeviceAlarmEntity> tbDeviceAlarms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .Build();
            base.OnConfiguring(optionsBuilder);
            //string connStr = $"Data Source=127.0.0.1;Initial Catalog=ScadaBase;User Id=sa;Password=123123;Trusted_Connection=True;Encrypt=false;";
            //string connectionStr = DbConfigManager.ConnectionStr;
            //optionsBuilder.UseSqlServer(connStr);
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"))
                .AddInterceptors(new MyDbCommandInterceptor())
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
