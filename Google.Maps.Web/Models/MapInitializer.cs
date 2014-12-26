using Google.Maps.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Google.Maps.Web.Models
{
    public class MapInitializer : DropCreateDatabaseIfModelChanges<MapContext>
    {
        protected override void Seed(MapContext context)
        {
            var favorites = new List<Favorite>
            {
                new Favorite() { Id = 1, Address = "Address somewhere", Latitude = 11.11111, Longitude = 2.222 },
                new Favorite() { Id = 2, Address = "Another adress", Latitude = 54.666, Longitude = 99.001 },
                new Favorite() { Id = 3, Address = "Sample avenue no 00", Latitude = -6.777, Longitude = 9.8765 },
            };

            favorites.ForEach(f => context.Favorites.Add(f));
            context.SaveChanges();
        }
    }
}