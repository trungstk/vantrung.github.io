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
    public class giohangsController : ApiController
    {
        private nuochoa1Entities1 db = new nuochoa1Entities1();

        // GET: api/giohangs
        public IQueryable<giohang> Getgiohangs()
        {
            return db.giohang;
        }
        [HttpGet]
        [Route("api/giohang/getallsp/{id}/{ghichu}")]
        public IHttpActionResult getallsp(int id, string ghichu)
        {
            var giohang = db.giohang.Where(x => x.idtk == id && x.ghichu == ghichu);
            if (!giohang.Any())
            {
                return NotFound();
            }
            return Ok(giohang);

        }
        [HttpGet]
        [Route("api/giohang/tongsl/{id}/{ghichu}")]
        public IHttpActionResult tongsl(int id, string ghichu)
        {
            var giohang = db.giohang.Where(x => x.idtk == id && x.ghichu == ghichu).Sum(x => x.sl); ;
            if (giohang == null)
            {
                return NotFound();
            }
            return Ok(giohang);

        }
        [HttpGet]
        [Route("api/giohang/tongtien/{id}/{ghichu}")]
        public IHttpActionResult tongtien(int id, string ghichu)
        {
            var giohang = db.giohang.Where(x => x.idtk == id && x.ghichu == ghichu).Sum(x => (int?)x.tongtien);
            if (giohang == null)
            {
                return NotFound();
            }
            return Ok(giohang);

        }
        [HttpGet]
        [Route("api/giohang/Getgiohang/{id}")]
        public IHttpActionResult Getgiohang(int id)
        {
            giohang giohang = db.giohang.Find(id);
            if (giohang == null)
            {
                return NotFound();
            }

            return Ok(giohang);
        }

        [HttpPut]
        [Route("api/giohang/Putgiohang/{id}")]
        public IHttpActionResult Putgiohang(int id, giohang giohang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != giohang.idgh)
            {
                return BadRequest();
            }

            db.Entry(giohang).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!giohangExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(giohang);
        }


        [HttpPost]
        [Route("api/giohang/addgiohang")]
        public IHttpActionResult Postgiohang(giohang giohang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.giohang.Add(giohang);
            db.SaveChanges();

            return Ok(giohang);
        }

        [HttpDelete]
        [Route("api/giohang/Deletegiohang/{id}")]
        public IHttpActionResult Deletegiohang(int id)
        {
            giohang giohang = db.giohang.Find(id);
            if (giohang == null)
            {
                return NotFound();
            }

            db.giohang.Remove(giohang);
            db.SaveChanges();

            return Ok(giohang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool giohangExists(int id)
        {
            return db.giohang.Count(e => e.idgh == id) > 0;
        }
    }
}