using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_TraSua.Models.Entities;
using PagedList;

namespace Web_TraSua.Controllers
{
    public class DatHangController : Controller
    {
        ShopModelData db = new ShopModelData();
        // GET: DatHang
        public ActionResult Index(int page = 1, int pageSize = 8)
        {
            if (Session["username"] == null) return RedirectToAction("Login", "Admin");
            else
            {
                var lst = db.DatHangs.SqlQuery("select" + "*from DatHang").ToList<DatHang>();

                var model = lst.ToPagedList(page, pageSize);
                return View(model);
            }
        }

        private IEnumerable<string> GetAllGhiChu()
        {
            return new List<string>
            {
                "Chưa xử lý",
                "Đang xử lý",
                "Đã xử lý",
            };
        }

        private IEnumerable<string> getallnote()
        {
            return new List<string>
            {
                "Chưa xử lý",
                "Đang xử lý",
                "Đã xử lý",
            };
        }

        //public ActionResult Create()
        //{
        //    if (Session["username"] == null) return RedirectToAction("../Admin/Login");
        //    else
        //    {
        //        List<KhachHang> catekhachhang = db.KhachHangs.ToList();
        //        SelectList catelistkhachhang = new SelectList(catekhachhang, "makh", "hotenkh");
        //        ViewBag.makh = catelistkhachhang;

        //        return View();
        //    }
        //}

        //[HttpPost]
        //public ActionResult Create(DatHang order)
        //{
        //    db.DatHangs.Add(order);
        //    db.SaveChanges();

        //    return RedirectToAction("Index");
        //}

        public ActionResult Edit(int madh)
        {
            if (Session["username"] == null) return RedirectToAction("Login","Admin");
            else
            {
                ViewBag.Note = GetAllGhiChu();

                var lst = db.DatHangs.Find(madh);

                return View(lst);
            }
        }

        [HttpPost]
        public ActionResult Edit(DatHang order)
        {
            DatHang dathang = db.DatHangs.Find(order.madh);
            if (dathang != null)
            {
                dathang.Note = order.Note;

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int madh)
        {
            if (Session["username"] == null) return RedirectToAction("Login","Admin");
            else
            {
                return RedirectToAction("Index", "CTDatHang", new { madh = madh});
            }
        }

        [HttpPost]
        public ActionResult Details(DatHang order)
        {
            return RedirectToAction("Index");
        }
      

        //public ActionResult Delete(int madh)
        //{
        //    if (Session["username"] == null) return RedirectToAction("../Admin/Login");
        //    else
        //    {
        //        var lst = db.DatHangs.Find(madh);
        //        return View(lst);
        //    }
        //}

        //[HttpPost]
        //public ActionResult Delete(DatHang order)
        //{
        //    //goi model, luu vao csdl
        //    DatHang dathang = db.DatHangs.Find(order.madh);
        //    if (dathang != null)
        //    {
        //        db.DatHangs.Remove(dathang);
        //        db.SaveChanges();
        //    }
        //        return RedirectToAction("Index");
        //}

        public ActionResult LeftAdmin()
        {
            return PartialView("~/Views/Shared/LeftAdmin.cshtml");
        }
    }
}