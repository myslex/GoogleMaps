using Google.Maps.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Google.Maps.Web.Models
{
    public class MapContext : DbContext
    {

        public MapContext()
            : base("MapContext")
        {
            Database.SetInitializer(new MapInitializer());
            this.Configuration.LazyLoadingEnabled = false;

            // because EntityFramework creates a 'proxy' of our class.
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Favorite> Favorites { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // fucking annoying..
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}