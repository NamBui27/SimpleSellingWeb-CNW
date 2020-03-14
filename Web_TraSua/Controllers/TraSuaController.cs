using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_TraSua.Models.Entities;
using PagedList;
using System.IO;

using System.Data.SqlClient;

namespace Web_TraSua.Controllers
{
    public class TraSuaController : Controller
    {
        ShopModelData DB = new ShopModelData();
        // GET: TraSua
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            if (Session["username"] == null) return RedirectToAction("Login","Admin");
            else
            {
                List<LoaiTraSua> cateLoaitra = DB.LoaiTraSuas.ToList();
                ViewBag.maloai = cateLoaitra;

                var lst = DB.TraSuas.SqlQuery("select" + "*from TraSua").ToList<TraSua>();

                var model = lst.ToPagedList(page, pageSize);
                return View(model);
            }         
        }

        public ActionResult Create()
        {
            if (Session["username"] == null) return RedirectToAction("Login","Admin");
            else
            {
                List<LoaiTraSua> listloaitra = DB.LoaiTraSuas.ToList();
                SelectList catelistloaitra = new SelectList(listloaitra, "maloai", "tenloai");
                ViewBag.maloai = catelistloaitra;

                return View();
            }
        }


        [HttpPost]
        public ActionResult Create(TraSua trasua, HttpPostedFileBase hinhanh)
        {
            if (hinhanh != null && hinhanh.ContentLength > 0)
            {
                var tenanh = Path.GetFileName(hinhanh.FileName);
                var link = Path.Combine(Server.MapPath("~/Content/img/"), tenanh);
                
                trasua.anhts = tenanh;
                hinhanh.SaveAs(link);
            }
            if (ModelState.IsValid)
            {
                DB.TraSuas.Add(trasua);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }     
            else return View(trasua);
          
        }    

        public ActionResult Edit(int mats)
        {
            if (Session["username"] == null) return RedirectToAction("Login","Admin");
            else
            {

                List<LoaiTraSua> listloaitra = DB.LoaiTraSuas.ToList();
                SelectList catelistloaitra = new SelectList(listloaitra, "maloai", "tenloai");
                ViewBag.maloai = catelistloaitra;

                var list = DB.TraSuas.Find(mats);
                return View(list);
            }
        }

        [HttpPost]
        public ActionResult Edit(TraSua trasua, HttpPostedFileBase hinhanh)
        {

            TraSua tra = DB.TraSuas.Find(trasua.mats);
            if (tra != null)
            {
                if (hinhanh != null && hinhanh.ContentLength > 0)
                {
                    var tenanh = Path.GetFileName(hinhanh.FileName);
                    var link = Path.Combine(Server.MapPath("~/Content/img/"), tenanh);

                    trasua.anhts = tenanh;
                    hinhanh.SaveAs(link);
                }
                else { }
                if (ModelState.IsValid)
                {
                    //tra.mats = trasua.mats;
                    tra.maloai = trasua.maloai;
                    tra.tents = trasua.tents;
                    tra.huongvi = trasua.huongvi;                  
                    tra.size = trasua.size;
                    tra.dongia = trasua.dongia;
                    tra.anhts = trasua.anhts;
                    tra.ghichu = trasua.ghichu;

                    DB.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            else return View(tra);
        }

       
        public ActionResult Details(int mats)
        {
            if (Session["username"] == null) return RedirectToAction("Login","Admin");
            else
            {
                var list = DB.TraSuas.Find(mats);
                return View(list);
            }
        }

        [HttpPost]
        public ActionResult Details(TraSua trasua)
        {
            TraSua tra = DB.TraSuas.Find(trasua.mats);
            if (tra != null)
            {
                tra.mats = trasua.mats;
                tra.tents = trasua.tents;
                tra.huongvi = trasua.huongvi;
                tra.maloai = trasua.maloai;
                tra.size = trasua.size;
                tra.dongia = trasua.dongia;
                tra.anhts = trasua.anhts;
                tra.ghichu = trasua.ghichu;
            }
                return RedirectToAction("Index");
        }

        public ActionResult Delete(int mats)
        {
            if (Session["username"] == null) return RedirectToAction("Login","Admin");
            else
            {
                var list = DB.TraSuas.Find(mats);
                return View(list);
            }
        }

        [HttpPost]
        public ActionResult Delete(TraSua trasua)
        {
            TraSua tra = DB.TraSuas.Find(trasua.mats);
            if(trasua !=null)
            {
                DB.TraSuas.Remove(tra);
                DB.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult LeftAdmin()
        {
            return PartialView("~/Views/Shared/LeftAdmin.cshtml");
        }

        public ActionResult Search(FormCollection f, int page = 1, int pageSize = 10)
        {
            if (Session["username"] == null) return RedirectToAction("Login","Admin");
            else
            {
                string tents = f["txtTenSP"].ToString();
                ViewBag.tents = tents;

                List<LoaiTraSua> cateLoaitra = DB.LoaiTraSuas.ToList();
                ViewBag.maloai = cateLoaitra;

                string tenloai = f["maloai"].ToString();
                ViewBag.tenloai = tenloai;

                string tugia = f["txtTuGia"].ToString();
                ViewBag.tugia = tugia;

                string dengia = f["txtDenGia"].ToString();
                ViewBag.dengia = dengia;

                if (tugia == "")
                {
                    tugia = "0";
                }
                if (dengia == "")
                {
                    dengia = "100000000000";
                }

                string query = "select mats, tents, anhts, huongvi, size, dongia, TraSua.maloai, LoaiTraSua.tenloai from TraSua, LoaiTraSua" +
                    " where TraSua.maloai=LoaiTraSua.maloai and tents like N'%" + tents + "%' and tenloai like N'%" + tenloai + "%' and dongia > " + tugia + " and dongia <" + dengia;

                var lst = DB.Database.SqlQuery<CTSanPham>(query).ToList().ToPagedList(page, pageSize);

                return View(lst);
            }
        }
                                     
    }
}