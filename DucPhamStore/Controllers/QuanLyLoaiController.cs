using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DucPhamStore.Models;

namespace DucPhamStore.Controllers
{
    public class QuanLyLoaiController : Controller
    {
        private DucPhamStoreEntities db = new DucPhamStoreEntities();

        // GET: QuanLyLoai
        public ActionResult Index(string key)
        {
            if(key == null)
                return View(db.Loais.ToList());
            var lstFind = db.Loais.Where(p => p.TenLoai.ToLower().Contains(key.ToLower()) || p.MaLoai.ToLower().Contains(key.ToLower())).ToList();
            return View(lstFind);
        }

        // GET: QuanLyLoai/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loai loai = db.Loais.Find(id);
            if (loai == null)
            {
                return HttpNotFound();
            }
            return View(loai);
        }

        // GET: QuanLyLoai/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuanLyLoai/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoai,TenLoai,Active")] Loai loai)
        {
            if (ModelState.IsValid)
            {
                db.Loais.Add(loai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loai);
        }

        // GET: QuanLyLoai/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loai loai = db.Loais.Find(id);
            if (loai == null)
            {
                return HttpNotFound();
            }
            return View(loai);
        }

        // POST: QuanLyLoai/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoai,TenLoai,Active")] Loai loai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loai);
        }

        // GET: QuanLyLoai/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loai loai = db.Loais.Find(id);
            if (loai == null)
            {
                return HttpNotFound();
            }
            return View(loai);
        }

        // POST: QuanLyLoai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Loai loai = db.Loais.Find(id);
            db.Loais.Remove(loai);
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
