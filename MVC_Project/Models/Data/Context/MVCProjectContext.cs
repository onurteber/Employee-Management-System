using MVC_Project.Models.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MVC_Project.Models.Data.Context
{
    public class MVCProjectContext:DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public MVCProjectContext()
        {
            Database.Connection.ConnectionString = "Server=.;Database=ProjectMVC;Trusted_Connection=True";
        }
        public DbSet<Departman> Departmanlar { get; set; }
        public DbSet<Personel> Personeller { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
    }
}