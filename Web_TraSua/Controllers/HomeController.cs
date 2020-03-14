using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_TraSua.Models.Entities;
using PagedList;
using System.Data.SqlClient;

namespace Web_TraSua.Controllers
{
    public class HomeController : Controller
    {
        ShopModelData db = new ShopModelData();

        private static string TenTS = "";
        private static string size = "";
        private static string tenloai = "";
        private static string tugia = "";
        private static string dengia = "";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products()
        {           
            return View();
        }

        public ActionResult Checkout()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Single(int id)
        {
            var trasua = db.TraSuas.SingleOrDefault(item => item.mats == id);
            if(trasua == null)
            {
                Response.StatusCode = 404;
                Response.StatusDescription = "Không có sản phẩm này";
            }
            return View(trasua);
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult InsertData()
        {
            string name = Request.Form["billing_full_name"];
            string phone = Request.Form["billing_phone"];
            string email = Request.Form["billing_email"];
            string addresstype = Request.Form["billing_address_1"];
            string address = Request.Form["billing_address_2"];

            ShoppingCart cart = (ShoppingCart)Session["cart"];
            List<Item> lst = new List<Item>();
            if(cart != null)
            {
                lst = cart.lst;
                if (db.KhachHangs.Where(q => q.hotenkh == name && q.sdt == phone && q.email == email).FirstOrDefault() == null)
                {
                    KhachHang khachhang = new KhachHang();
                    khachhang.hotenkh = name;
                    khachhang.diachi = addresstype + " - " + address;
                    khachhang.email = email;
                    khachhang.sdt = phone;

                    db.KhachHangs.Add(khachhang);
                    db.SaveChanges();
                }

                DatHang dathang = new DatHang();
                var x = db.KhachHangs.Where(q => q.hotenkh == name && q.sdt == phone && q.email == email).FirstOrDefault();
                dathang.makh = x.makh;
                dathang.ngaytao = DateTime.Today;
                dathang.Note = "Chưa được xử lý";

                db.DatHangs.Add(dathang);
                db.SaveChanges();


                CTDatHang cTDatHang = new CTDatHang();
                foreach(var item in lst)
                {
                    cTDatHang.madh = dathang.madh;
                    cTDatHang.mats = item.id;
                    cTDatHang.soluong = item.amount;
                    cTDatHang.dongia = (decimal)item.price;
                    cTDatHang.thanhtien = (decimal)(item.price * item.amount);

                    db.CTDatHangs.Add(cTDatHang);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult InfoProduct(int page = 1, int pageSize = 9)
        {
            var lst = db.Database.SqlQuery<TraSua>("SEARCHSP @TENTS", new SqlParameter("TENTS", TenTS)).ToList();

            var model = lst.ToPagedList(page, pageSize);

            return PartialView("~/Views/Shared/ViewInfoSanPham.cshtml", model);
        }

        [HttpPost]
        public ActionResult Search(string tents)
        {
            TenTS = tents;
            InfoProduct();
            return RedirectToAction("Products");
        }

        //public ActionResult filter_query(int page = 1, int pageSize = 9)
        //{
        //    string query = "select * from TraSua" +
        //            " where (size like N'% @size %') and (maloai in ( select maloai from LoaiTraSua where tenloai like N'% @tenloai %')) and (dongia between @tugia and  @dengia )";

        //    var lst = db.Database.SqlQuery<TraSua>(query, new SqlParameter("size", size), new SqlParameter("tenloai", tenloai), new SqlParameter("tugia", tugia), new SqlParameter("dengia", dengia)).ToList();

        //    var model = lst.ToPagedList(page, pageSize);
        //    return PartialView("~/Views/Shared/ViewInfoSanPham.cshtml", model);
        //}

        //[HttpPost]
        //public ActionResult Filter(string Size, string Loai, string Dau, string Cuoi)
        //{
        //    size = Size; tenloai = Loai; tugia = Dau; dengia = Cuoi;
        //    filter_query();
        //    return RedirectToAction("Products");
        //}
    }
}