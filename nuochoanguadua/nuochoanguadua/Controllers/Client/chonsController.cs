using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using nuochoanguadua.Models;

namespace nuochoanguadua.Controllers.Client
{
    public class chonsController : Controller
    {
        private nuochoa1Entities1 db = new nuochoa1Entities1();

        // GET: chons
        public ActionResult Index()
        {
            return View(db.chon.ToList());
        }

        // GET: chons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chon chon = db.chon.Find(id);
            if (chon == null)
            {
                return HttpNotFound();
            }
            return View(chon);
        }

        // GET: chons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: chons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_l,loaihang,ten,tien,ghichu")] chon chon)
        {
            if (ModelState.IsValid)
            {
                db.chon.Add(chon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chon);
        }

        // GET: chons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chon chon = db.chon.Find(id);
            if (chon == null)
            {
                return HttpNotFound();
            }
            return View(chon);
        }

        // POST: chons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_l,loaihang,ten,tien,ghichu")] chon chon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chon);
        }

        // GET: chons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chon chon = db.chon.Find(id);
            if (chon == null)
            {
                return HttpNotFound();
            }
            return View(chon);
        }

        // POST: chons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            chon chon = db.chon.Find(id);
            db.chon.Remove(chon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
