using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace vtUyg.ViewModel
{
    public class DilekContext : DbContext
    {
        public DilekContext()
        {
            Database.Connection.ConnectionString = "Data Source=.;Initial Catalog=DilekCodeFirst;Integrated Security=True";
        }

        public DbSet<kayitModel> Kayitlar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}