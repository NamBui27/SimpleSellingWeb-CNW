using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_TraSua.Models.Entities;

namespace Web_TraSua.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Add(int id)
        {
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            if(cart == null)
            {
                cart = new ShoppingCart();
            }
            ShopModelData db = new ShopModelData();
            TraSua trasua = db.TraSuas.Find(id);
            if(trasua != null)
            {
                cart.InsertItem(trasua.mats, trasua.anhts, trasua.tents, (double)trasua.dongia);
            }

            Session["cart"] = cart;
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Remove(int id)
        {
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            if (cart == null)
            {
                cart = new ShoppingCart();
            }        
            cart.RemoveItem(id);
            Session["cart"] = cart;
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Update(int id, FormCollection f)
        {
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            if (cart == null)
            {
                cart = new ShoppingCart();
            }
            string s = f["Qty"].ToString();
            int x = int.Parse(s);
            cart.UpdateAmount(id, x);
            Session["cart"] = cart;
            return Redirect(Request.UrlReferrer.ToString());
        }

    }
}