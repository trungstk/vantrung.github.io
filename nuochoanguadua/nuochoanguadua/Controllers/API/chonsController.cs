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
using nuochoanguadua.Models;

namespace nuochoanguadua.Controllers.API
{
    public class chonsController : ApiController
    {
        private nuochoa1Entities1 db = new nuochoa1Entities1();

        [HttpGet]
        [Route("api/chon/getall")]
        public IQueryable<chon> Getchons()
        {
            return db.chon;
        }
        [HttpGet]
        [Route("api/chon/Getall_chon/{id}")]
        public IHttpActionResult Getall_chon(string id)
        {
            var chon = db.chon.Where(x => x.loaihang == id);
            if (!chon.Any())
            {
                return NotFound();
            }
            return Ok(chon);

        }
        [HttpGet]
        [Route("api/chon/Getchon/{id}")]
        public IHttpActionResult Getchon(int id)
        {
            chon chon = db.chon.Find(id);
            if (chon == null)
            {
                return NotFound();
            }

            return Ok(chon);
        }

        [HttpPut]
        [Route("api/chon/Putchon/{id}")]
        public IHttpActionResult Putchon(int id, chon chon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chon.id_l)
            {
                return BadRequest();
            }

            db.Entry(chon).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!chonExists(id))
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

        [HttpPost]
        [Route("api/chon/Postchon")]
        public IHttpActionResult Postchon(chon chon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.chon.Add(chon);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = chon.id_l }, chon);
        }

        [HttpDelete]
        [Route("api/chon/Deletechon/{id}")]
        public IHttpActionResult Deletechon(int id)
        {
            chon chon = db.chon.Find(id);
            if (chon == null)
            {
                return NotFound();
            }

            db.chon.Remove(chon);
            db.SaveChanges();

            return Ok(chon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool chonExists(int id)
        {
            return db.chon.Count(e => e.id_l == id) > 0;
        }
    }
}