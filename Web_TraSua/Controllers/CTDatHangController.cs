using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_TraSua.Models.Entities;
using PagedList;

namespace Web_TraSua.Controllers
{
    public class CTDatHangController : Controller
    {
        ShopModelData db = new ShopModelData();
        // GET: CTDatHang
        public ActionResult Index(int madh, int page = 1, int pageSize =5)
        {
            if (Session["username"] == null) return RedirectToAction("Login", "Admin");
            else
            {
                if (madh == null)
                {

                    var lst = ((from c in db.CTDatHangs select c).ToList()).ToPagedList(page, pageSize);
                    return View(lst);
                }
                else
                {
                    var lst = ((from c in db.CTDatHangs where c.madh == madh select c).ToList()).ToPagedList(page, pageSize);
                    return View(lst);
                }
            }
        }

        //public ActionResult Create()
        //{
        //    if (Session["username"] == null) return RedirectToAction("../Admin/Login");
        //    else
        //    {
        //        List<TraSua> catetrasua = db.TraSuas.ToList();
        //        SelectList catelisttrasua = new SelectList(catetrasua, "mats", "tents");
        //        ViewBag.mats = catelisttrasua;



        //        return View();
        //    }
        //}

        //[HttpPost]
        //public ActionResult Create(CTDatHang chitietdh)
        //{
        //    //goi Model, luu vao csdl
        //    db.CTDatHangs.Add(chitietdh);
        //    db.SaveChanges();

        //    return RedirectToAction("Index");
        //}

        //public ActionResult Edit(int mactdh)
        //{
        //    if (Session["username"] == null) return RedirectToAction("../Admin/Login");
        //    else
        //    {
        //        List<TraSua> catetrasua = db.TraSuas.ToList();
        //        SelectList catelisttrasua = new SelectList(catetrasua, "mats", "tents");
        //        ViewBag.mats = catelisttrasua;

        //        var lst = db.CTDatHangs.Find(mactdh);

        //        return View(lst);
        //    }
        //}

        //[HttpPost]
        //public ActionResult Edit(CTDatHang ctdathang)
        //{
        //    CTDatHang chitietdh = db.CTDatHangs.Find(ctdathang.mactdh);
        //    if(chitietdh != null)
        //    {
        //        chitietdh.mats = ctdathang.mats;
        //        chitietdh.madh = ctdathang.madh;
        //        chitietdh.soluong = ctdathang.soluong;
        //        chitietdh.dongia = ctdathang.dongia;
        //        chitietdh.thanhtien = ctdathang.thanhtien;

        //        db.SaveChanges();
        //    }

        //    return RedirectToAction("Index", new { id = chitietdh.madh });
        //}

        //public ActionResult Delete(int mactdh)
        //{
        //    if (Session["username"] == null) return RedirectToAction("../Admin/Login");
        //    else
        //    {
        //        var lst = db.CTDatHangs.Find(mactdh);
        //        return View(lst);
        //    }
        //}

        //[HttpPost]
        //public ActionResult Delete(CTDatHang ctdathang)
        //{
        //    //goi model, luu vao csdl
        //    CTDatHang chitietdh = db.CTDatHangs.Find(ctdathang.mactdh);
        //    if(chitietdh != null)
        //    {
        //        db.CTDatHangs.Remove(chitietdh);
        //        db.SaveChanges();
        //    }

        //    return RedirectToAction("Index", new { id = chitietdh.madh});
        //}

        public ActionResult LeftAdmin()
        {
            return PartialView("~/Views/Shared/LeftAdmin.cshtml");
        }
    }
}