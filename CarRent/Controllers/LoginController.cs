using CarRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRent.Controllers
{
    public class LoginController : Controller
    {
        CarRentContext db = new CarRentContext();
        // GET: Login
        public ActionResult Index()
        {
            if (Session["Yonetici"] != null)
                return Redirect("/Panel/Index");
            return View();
        }

        [HttpPost]
        public ActionResult Index(string eposta, string sifre)
        {
            
            Kullanici k = db.Kullanici.Where(x => x.eposta == eposta && x.sifre == sifre).SingleOrDefault();
            if (k == null)
            {
                ViewBag.Sonuc = "Böyle bir kullanıcı yoktur.";
                return View();
            }
            else
            {
                KullaniciYetki kullaniciYetki = db.KullaniciYetki.Where(x => x.kullaniciID == k.kullaniciID).FirstOrDefault();
                if (kullaniciYetki.yetkiID == 1)
                {
                    Session["Yonetici"] = k;
                }
                else
                {
                    Session["Kullanici"] = k;
                }
                
                Response.Redirect("/Panel/Index");
            }
            return View();
        }

        public ActionResult Cikis()
        {
            Session.Abandon();
            return Redirect("/Home/Anasayfa");
        }

    }
}