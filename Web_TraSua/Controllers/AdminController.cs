using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_TraSua.Models.Entities;
using PagedList;

namespace Web_TraSua.Controllers
{
    public class AdminController : Controller
    {
        ShopModelData db = new ShopModelData();
        // GET: QuanLy
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckLogin()
        {
            string us = Request.Form["us"];
            string mk = Request.Form["mk"];
            var result = db.NhanViens.Where(p => p.taikhoannv == us && p.matkhaunv == mk);
            if (result.Count() > 0)
            {
                Session["username"] = us;
                return RedirectToAction("List");
            }
            else
            {
                TempData["msg"] = "Đăng nhập không thành công !!";
                return RedirectToAction("Login");
            }

        }

        public ActionResult List(int page = 1, int pageSize = 10)
        {
            if (Session["username"] == null) return RedirectToAction("Login");
            else
            {
                var lst = db.NhanViens.SqlQuery("select" + "*from NhanVien").ToList<NhanVien>();

                var model = lst.ToPagedList(page, pageSize);
                return View(model);
            }
        }

        public ActionResult Create()
        {
            if (Session["username"] == null) return RedirectToAction("Login");
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Create(NhanVien nhanvien)
        {
            db.NhanViens.Add(nhanvien);
            db.SaveChanges();

            return RedirectToAction("List");
        }

        public ActionResult Edit(int manv)
        {
            if (Session["username"] == null) return RedirectToAction("Login");
            else
            {

                var list = db.NhanViens.Find(manv);
                return View(list);
            }
        }

        [HttpPost]
        public ActionResult Edit(NhanVien nhanvien)
        {
            NhanVien nv = db.NhanViens.Find(nhanvien.manv);
            if (nv != null)
            {
                nv.tennv = nhanvien.tennv;
                nv.taikhoannv = nhanvien.taikhoannv;
                nv.matkhaunv = nhanvien.matkhaunv;

                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        public ActionResult Delete(int manv)
        {
            if (Session["username"] == null) return RedirectToAction("Login");
            else
            {
                var list = db.NhanViens.Find(manv);
                return View(list);
            }
        }

        [HttpPost]
        public ActionResult Delete(NhanVien nhanvien)
        {
            NhanVien nv = db.NhanViens.Find(nhanvien.manv);
            if (nv != null)
            {
                db.NhanViens.Remove(nhanvien);
                db.SaveChanges();
            }
                return RedirectToAction("List");
        }

        public ActionResult LeftAdmin()
        {
            return PartialView("~/Views/Shared/LeftAdmin.cshtml");
        }
    }
}