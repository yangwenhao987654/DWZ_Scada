using DWZ_Scada.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.DAL.DBContext
{
    public class MyDbContext : DbContext
    {

        public DbSet<OpUser> OpUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connStr = $"Data Source=127.0.0.1;Initial Catalog=ScadaBase;User Id=sa;Password=123123;Trusted_Connection=True;Encrypt=false;";
            //string connectionStr = DbConfigManager.ConnectionStr;
            optionsBuilder.UseSqlServer(connStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
