using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DucPhamStore.Models;
using PagedList;

namespace DucPhamStore.Controllers
{
    public class QuanLyLoaiController : Controller
    {
        private DucPhamStoreEntities db = new DucPhamStoreEntities();

        // GET: QuanLyLoai
        public ActionResult Index(string key,string trangthai,int? page)
        {
            var t = db.Loais.OrderBy(p=>p.TenLoai).ToList();
            if(key != null)
            {
                ViewBag.Key = key;
                t = t.Where(p => p.TenLoai.ToLower().Contains(key.ToLower()) || p.MaLoai.ToLower().Contains(key.ToLower())).ToList();
            }
            if(trangthai != null)
            {
                ViewBag.TrangThai = trangthai;
                if (trangthai.Equals("active"))
                    t = t.Where(p => p.Active == true).ToList();
                if (trangthai.Equals("non-active"))
                    t = t.Where(p => p.Active == false).ToList();
            }
            int pageNumber = page??1;
            int pageSize = 6;
            return View(t.ToPagedList(pageNumber,pageSize));
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

        // POST: QuanLyLoai/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string MaLoai)
        {
            var t = db.Loais.Where(p => p.MaLoai.Equals(MaLoai));
            if(t.Count() == 0)
            {
                return HttpNotFound();
            }
            Loai loai = t.First();
            db.Loais.Remove(loai);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //POST: QuanLyLoai/Active
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Active(string MaLoai)
        {
            var t = db.Loais.Where(p => p.MaLoai.Equals(MaLoai));
            if (t.Count() == 0)
            {
                return HttpNotFound();
            }
            Loai loai = t.First();
            loai.Active = !loai.Active;
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
