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
    public class donhangsController : ApiController
    {
        private nuochoa1Entities1 db = new nuochoa1Entities1();

        [HttpGet]
        [Route("api/donhang/Getdonhangs")]
        public IQueryable<donhang> Getdonhangs()
        {
            return db.donhang;
        }
        [HttpGet]
        [Route("api/donhang/getadhllsp/{id}/{hanhchinh}")]
        public IHttpActionResult getadhllsp(int id, string hanhchinh)
        {
            var donhang = db.donhang.Where(x => x.idtk == id && x.hanhchinh == hanhchinh);
            if (!donhang.Any())
            {
                return NotFound();
            }
            return Ok(donhang);

        }
        [HttpGet]
        [Route("api/donhang/Getdonhangs/{id}")]
        public IHttpActionResult Getdonhang(int id)
        {
            donhang donhang = db.donhang.Find(id);
            if (donhang == null)
            {
                return NotFound();
            }

            return Ok(donhang);
        }

        [HttpPut]
        [Route("api/donhang/Putdonhang/{id}")]
        public IHttpActionResult Putdonhang(int id, donhang donhang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != donhang.iddh)
            {
                return BadRequest();
            }

            db.Entry(donhang).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!donhangExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(donhang);
        }

        [HttpPost]
        [Route("api/donhang/Postdonhang")]
        public IHttpActionResult Postdonhang(donhang donhang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.donhang.Add(donhang);
            db.SaveChanges();

            return Ok(donhang);
        }
        // Thống kê tài khoản này đã mua đc bao nhiêu tiền

        [HttpGet]
        [Route("api/revenue/{Account}")]
        public IHttpActionResult ThongKeTheoTaiKhoan(int Account)
        {
            int tong = 0;
            // Lấy ra những đơn hàng có ngày tương ứng
            var orders = db.donhang.Where(n => n.idtk == Account && n.hanhchinh == "Đã giao");

            // Duyệt chi tiết của đơn hàng và lấy ra tổng tiền của đơn hàng đó
            foreach (var order in orders)
            {
                var orderDetails = db.giohang.Where(x => x.idgh == order.idgh);
                foreach (var detail in orderDetails)
                    foreach (var x in orderDetails)
                    {
                        tong += x.tongtien;
                    }
            }

            return Ok(tong);
        }
        // Thống kê số lượng đơn hàng đã mua 
        [HttpGet]
        [Route("api/ThongKeTaiKhoanTheoSoLuong/{Account}")]
        public IHttpActionResult ThongKeTheoTaiKhoanTheoSoLuong(int Account)
        {
            int tong = 0;
            // Lấy ra những đơn hàng có ngày tương ứng
            var orders = db.donhang.Where(n => n.idtk == Account && n.hanhchinh == "Đã giao");

            // Duyệt chi tiết của đơn hàng và lấy ra tổng tiền của đơn hàng đó
            foreach (var order in orders)
            {
                var orderDetails = db.giohang.Where(x => x.idgh == order.idgh);
                foreach (var detail in orderDetails)
                {
                    // Assuming there is a product table and a relationship between order details and products based on idsanpham
                    tong += detail.sl;
                }
            }

            return Ok(tong);
        }
        [HttpDelete]
        [Route("api/donhang/Deletedonhang/{id}")]
        public IHttpActionResult Deletedonhang(int id)
        {
            donhang donhang = db.donhang.Find(id);
            if (donhang == null)
            {
                return NotFound();
            }

            db.donhang.Remove(donhang);
            db.SaveChanges();

            return Ok(donhang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool donhangExists(int id)
        {
            return db.donhang.Count(e => e.iddh == id) > 0;
        }
    }
}