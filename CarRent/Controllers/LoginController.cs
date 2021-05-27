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
                TempData["Mesaj"] = "Böyle bir kullanıcı yoktur.";
                return View();
            }
            else
            {
                List<KullaniciYetki> kullaniciYetki = db.KullaniciYetki.Where(x => x.kullaniciID == k.kullaniciID).ToList();
                foreach (var item in kullaniciYetki)
                {
                    if (item.yetkiID == 1)
                    {
                        Session["Yonetici"] = k;
                    }
                    else if (item.yetkiID == 2)
                    {
                        Session["Kullanici"] = k;
                    }
                }
            }
            return RedirectToAction("Anasayfa", "Home");
        }

        public ActionResult Cikis()
        {
            Session.Abandon();
            return Redirect("/Home/Anasayfa");
        }

        public ActionResult KayitOl(string ad, string soyad, string eposta, string sifre)
        {

            if (eposta != null && sifre != null && ad != null && soyad != null)
            {
                Kullanici kul = new Kullanici()
                {
                    ad = ad,
                    soyad = soyad,
                    eposta = eposta,
                    sifre = sifre
                };
                KullaniciYetki kullaniciYetki = new KullaniciYetki()
                {
                    kullaniciID = kul.kullaniciID,
                    yetkiID = 2
                };

                db.Kullanici.Add(kul);
                db.KullaniciYetki.Add(kullaniciYetki);
                db.SaveChanges();

                TempData["Mesaj"] = "Kayıt Başarıyla Yapıldı";
                return RedirectToAction("Anasayfa", "Home");
            }
            else
            {
                TempData["Mesaj"] = "Ad soyad , Mail veya Şifre boş olamaz";
                return RedirectToAction("Anasayfa", "Home");
            }
        }

    }
}