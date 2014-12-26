using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Google.Maps.Web.Models;

namespace Google.Maps.Web.Controllers
{
    public class FavoritesController : ApiController
    {
        private MapContext db = new MapContext();

        // GET: api/Favorites
        public IQueryable<Favorite> GetFavorites()
        {
            return db.Favorites;
        }

        // GET: api/Favorites/5
        [ResponseType(typeof(Favorite))]
        public async Task<IHttpActionResult> GetFavorite(int id)
        {
            Favorite favorite = await db.Favorites.FindAsync(id);
            if (favorite == null)
                return NotFound();

            return Ok(favorite);
        }

        // PUT: api/Favorites/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFavorite(int id, Favorite favorite)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != favorite.Id)
                return BadRequest();

            db.Entry(favorite).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteExists(id))
                    return NotFound();
                else
                    throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Favorites
        [ResponseType(typeof(Favorite))]
        public async Task<IHttpActionResult> PostFavorite(Favorite favorite)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var temp = await db.Favorites.SingleOrDefaultAsync(f => f.Address == favorite.Address) ?? db.Favorites.Add(favorite); await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = favorite.Id }, favorite);
        }

        // DELETE: api/Favorites/5
        [ResponseType(typeof(Favorite))]
        public async Task<IHttpActionResult> DeleteFavorite(int id)
        {
            Favorite favorite = await db.Favorites.FindAsync(id);
            if (favorite == null)
                return NotFound();

            db.Favorites.Remove(favorite);
            await db.SaveChangesAsync();

            return Ok(favorite);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }

        private bool FavoriteExists(int id)
        {
            return db.Favorites.Count(e => e.Id == id) > 0;
        }
    }
}