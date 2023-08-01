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
    public class tksController : ApiController
    {
        private nuochoa1Entities1 db = new nuochoa1Entities1();

        // GET: api/tks
        public IQueryable<tk> Gettk()
        {
            return db.tk;
        }

        [HttpGet]
        [Route("api/tk/gettt/{id}")]
        public IHttpActionResult gettt(int id)
        {
            tk tk = db.tk.Find(id);
            if (tk == null)
            {
                return NotFound();
            }

            return Ok(tk);
        }
        // GET: api/tks/5
        [HttpGet]
        [Route("api/tk/kiemtra/{email}/{mk}")]
        public IHttpActionResult kiemtra(string email, string mk)
        {
            var tk = db.tk.Where(x => x.email == email && x.mk == mk);
            if (!tk.Any())
            {
                return NotFound();
            }

            return Ok(tk);
        }

        [HttpPut]
        [Route("api/tk/Puttk/{id}")]
        public IHttpActionResult Puttk(int id, tk tk)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tk.idtk)
            {
                return BadRequest();
            }

            db.Entry(tk).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tkExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(tk);
        }

        [HttpPost]
        [Route("api/tk/Posttk")]
        public IHttpActionResult Posttk(tk tk)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tk.Add(tk);
            db.SaveChanges();

            return Ok(tk);
        }

        [HttpDelete]
        [Route("api/tk/Deletetk/{id}")]
        public IHttpActionResult Deletetk(int id)
        {
            tk tk = db.tk.Find(id);
            if (tk == null)
            {
                return NotFound();
            }

            db.tk.Remove(tk);
            db.SaveChanges();

            return Ok(tk);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tkExists(int id)
        {
            return db.tk.Count(e => e.idtk == id) > 0;
        }
    }
}