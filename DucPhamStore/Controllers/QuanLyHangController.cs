using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DucPhamStore.Models;
using PagedList;

namespace DucPhamStore.Controllers
{
    public class QuanLyHangController : Controller
    {
        private DucPhamStoreEntities db = new DucPhamStoreEntities();
        // GET: QuanLyHang
        public ActionResult Index(string key,string trangthai,int? page)
        {
            var t = db.Hangs.OrderBy(p => p.TenHang).ToList();
            if (key != null)
                t = t.Where(p => p.TenHang.ToLower().Contains(key.ToLower()) || p.MaHang.ToLower().Contains(key.ToLower())).ToList();
            if(trangthai != null)
            {
                if (trangthai.Equals("active"))
                {
                    t = t.Where(p => p.Active == true).ToList();
                    ViewBag.Key = key;
                }
                if (trangthai.Equals("non-active"))
                {
                    t = t.Where(p => p.Active == false).ToList();
                    ViewBag.TrangThai = trangthai;
                }     
            }
            int pageNumber = page ?? 1;
            int pageSize = 6;
            return View(t.ToPagedList(pageNumber,pageSize));
        }

        //POST: QuanLyHang/Active
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Active(string MaHang)
        {
            if (MaHang == null)
                return HttpNotFound();
            var t = db.Hangs.Where(p => p.MaHang.Equals(MaHang));
            if (t.Count() == 0)
                return HttpNotFound();
            Hang hang = t.First();
            hang.Active = !hang.Active;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //POST: QuanLyHang/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string MaHang)
        {
            if (MaHang == null)
                return HttpNotFound();
            var t = db.Hangs.Where(p => p.MaHang.Equals(MaHang));
            if (t.Count() == 0)
                return HttpNotFound();
            Hang hang = t.First();
            db.Hangs.Remove(hang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}