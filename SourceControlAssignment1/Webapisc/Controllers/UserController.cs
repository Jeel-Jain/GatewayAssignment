using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Webapisc.Models;

namespace Webapisc.Controllers
{
    public class UserController : ApiController
    {
        private ProductEntities db = new ProductEntities();

        // GET: api/User
        public IQueryable<tbl_user> Gettbl_user()
        {
            return db.tbl_user;
        }

        // GET: api/User/5
        [ResponseType(typeof(tbl_user))]
        public IHttpActionResult Gettbl_user(long id)
        {
            tbl_user tbl_user = db.tbl_user.Find(id);
            if (tbl_user == null)
            {
                return NotFound();
            }

            return Ok(tbl_user);
        }

        // PUT: api/User/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_user(long id, tbl_user tbl_user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_user.Id)
            {
                return BadRequest();
            }

            db.Entry(tbl_user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_userExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/User
        [ResponseType(typeof(tbl_user))]
        public IHttpActionResult Posttbl_user(tbl_user tbl_user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_user.Add(tbl_user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_user.Id }, tbl_user);
        }

        // DELETE: api/User/5
        [ResponseType(typeof(tbl_user))]
        public IHttpActionResult Deletetbl_user(long id)
        {
            tbl_user tbl_user = db.tbl_user.Find(id);
            if (tbl_user == null)
            {
                return NotFound();
            }

            db.tbl_user.Remove(tbl_user);
            db.SaveChanges();

            return Ok(tbl_user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_userExists(long id)
        {
            return db.tbl_user.Count(e => e.Id == id) > 0;
        }
    }
}