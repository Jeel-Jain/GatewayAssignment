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
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ProductController : ApiController
    {
        private ProductEntities db = new ProductEntities();

        // GET: api/Product
        public IQueryable<tbl_product> Gettbl_product()
        {
            return db.tbl_product;
        }

        // GET: api/Product/5
        [ResponseType(typeof(tbl_product))]
        public IHttpActionResult Gettbl_product(long id)
        {
            tbl_product tbl_product = db.tbl_product.Find(id);
            if (tbl_product == null)
            {
                return NotFound();
            }

            return Ok(tbl_product);
        }

        // PUT: api/Product/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_product(long id, tbl_product tbl_product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_product.Id)
            {
                return BadRequest();
            }

            db.Entry(tbl_product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_productExists(id))
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

        // POST: api/Product
        [ResponseType(typeof(tbl_product))]
        public IHttpActionResult Posttbl_product(tbl_product tbl_product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_product.Add(tbl_product);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_product.Id }, tbl_product);
        }

        // DELETE: api/Product/5
        [ResponseType(typeof(tbl_product))]
        public IHttpActionResult Deletetbl_product(long id)
        {
            tbl_product tbl_product = db.tbl_product.Find(id);
            if (tbl_product == null)
            {
                return NotFound();
            }

            db.tbl_product.Remove(tbl_product);
            db.SaveChanges();

            return Ok(tbl_product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_productExists(long id)
        {
            return db.tbl_product.Count(e => e.Id == id) > 0;
        }
    }
}