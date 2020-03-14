using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_TraSua.Models.Entities;
using PagedList;

namespace Web_TraSua.Controllers
{
    public class KhachHangController : Controller
    {
        ShopModelData DB = new ShopModelData();
        // GET: KhachHang
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            if (Session["username"] == null) return RedirectToAction("Login", "Admin");
            else
            {
                var lst = DB.KhachHangs.SqlQuery("select" + "*from KhachHang").ToList<KhachHang>();

                var model = lst.ToPagedList(page, pageSize);
                return View(model);

            }
        }

        public ActionResult Create()
        {
            if (Session["username"] == null) return RedirectToAction("Login", "Admin");
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Create(KhachHang khach)
        {
            DB.KhachHangs.Add(khach);
            DB.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int makh)
        {
            if (Session["username"] == null) return RedirectToAction("Login","Admin");
            else
            {
                var list = DB.KhachHangs.Find(makh);
                return View(list);

            }
        }

        [HttpPost]
        public ActionResult Edit(KhachHang khach)
        {
            KhachHang khachhang = DB.KhachHangs.Find(khach.makh);
            if (khachhang != null)
            {
                khachhang.makh = khach.makh;
                khachhang.hotenkh = khach.hotenkh;
                khachhang.diachi = khach.diachi;
                khachhang.sdt = khach.sdt;
                khachhang.email = khach.email;
                khachhang.taikhoan = khach.taikhoan;
                khachhang.matkhau = khach.matkhau;

                DB.SaveChanges();
            }
                return RedirectToAction("Index");
        }

        public ActionResult Details(int makh, string hotenkh, int sdt, string diachi, string email, string taikhoan, string matkhau)
        {
            if (Session["username"] == null) return RedirectToAction("Login", "Admin");
            else
            {
                KhachHang kh = new KhachHang();
                kh.makh = makh;
                kh.hotenkh = hotenkh;
                //kh.sdt = sdt;
                kh.diachi = diachi;
                kh.email = email;
                kh.taikhoan = taikhoan;
                //kh.matkhau = "abc" + i;

                return View(kh);
            }
        }

        [HttpPost]
        public ActionResult Details(KhachHang kh)
        {
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int makh)
        {
            if (Session["username"] == null) return RedirectToAction("Login","Admin");
            else
            {
                var list = DB.KhachHangs.Find(makh);
                return View(list);
            }
        }

        [HttpPost]
        public ActionResult Delete(KhachHang khach)
        {
            KhachHang khachhang = DB.KhachHangs.Find(khach.makh);
            if (khachhang != null)
            {
                DB.KhachHangs.Remove(khachhang);
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