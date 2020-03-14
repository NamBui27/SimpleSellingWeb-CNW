using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_TraSua.Models.Entities;
using PagedList;

namespace Web_TraSua.Controllers
{
    public class LoaiTraSuaController : Controller
    {
        ShopModelData DB = new ShopModelData();
        // GET: LoaiTraSua
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            if (Session["username"] == null) return RedirectToAction("Login","Admin");
            else
            {
                var list = DB.LoaiTraSuas.SqlQuery("Select * from LoaiTraSua").ToList<LoaiTraSua>();


                var model = list.ToPagedList(page, pageSize);
                return View(model);
            }
        }

        public ActionResult Create()
        {
            if (Session["username"] == null) return RedirectToAction("Login","Admin");
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Create(LoaiTraSua loaitra)
        {
            DB.LoaiTraSuas.Add(loaitra);
            DB.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int maloai)
        {
            if (Session["username"] == null) return RedirectToAction("Login","Admin");
            else
            {
                var list = DB.LoaiTraSuas.Find(maloai);
                return View(list);
            }
        }

        [HttpPost]
        public ActionResult Edit(LoaiTraSua loaitra)
        {
            LoaiTraSua loaitrasua = DB.LoaiTraSuas.Find(loaitra.maloai);
            if (loaitra != null)
            {
                loaitrasua.tenloai = loaitra.tenloai;
                loaitrasua.maloai = loaitra.maloai;


                DB.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int maloai, string tenloai)
        {
            if (Session["username"] == null) return RedirectToAction("Login","Admin");
            else
            {
                LoaiTraSua loaitra = new LoaiTraSua();
                loaitra.tenloai = tenloai;
                loaitra.maloai = maloai;

                return View(loaitra);
            }
        }

        [HttpPost]
        public ActionResult Details(LoaiTraSua loaitra)
        {
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int maloai)
        {
            if (Session["username"] == null) return RedirectToAction("Login","Admin");
            else
            {
                var list = DB.LoaiTraSuas.Find(maloai);
                return View(list);
            }
        }

        [HttpPost]
        public ActionResult Delete(LoaiTraSua loaitra)
        {
            LoaiTraSua loaitrasua = DB.LoaiTraSuas.Find(loaitra.maloai);
            if (loaitra != null)
            {
                DB.LoaiTraSuas.Remove(loaitrasua);
                DB.SaveChanges();
            }
                return RedirectToAction("Index");
        }

        public ActionResult LeftAdmin()
        {
            return PartialView("~/Views/Shared/LeftAdmin.cshtml");
        }
    }
}