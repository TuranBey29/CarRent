using CarRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRent.Controllers
{
    public class HomeController : Controller
    {
        CarRentContext db = new CarRentContext();
        // GET: Home
        public ActionResult Anasayfa()
        {
            AnasayfaPageModel anasayfaPageModel = new AnasayfaPageModel()
            {
                Arac = db.Arac.ToList(),
                AracMarka = db.AracMarka.ToList(),
                AracModel = db.AracModel.ToList(),
                SiteAyar = db.SiteAyar.FirstOrDefault()
            };

            return View(anasayfaPageModel);
        }
        public ActionResult Araclar()
        {
            return View(db.Arac.ToList());
        }
        public JsonResult IlceListeGetir(int id)
        {
            return Json(db.Ilce.Where(x => x.ilID == id).ToList());
        }
        [HttpPost]
        public ActionResult AracKirala(int id, DateTime baslangic, DateTime bitis)
        {
            try
            {
                if (bitis < baslangic || bitis == baslangic)
                {
                    TempData["Mesaj"] = "Teslim tarihi başlangıç tarihinden önce olamaz!";
                    return RedirectToAction("Araclar");
                }
                int aracCount = db.Arac.Where(x => x.aracID == id).Count();
                if (aracCount < 1)
                {
                    TempData["Mesaj"] = "Kiralanmak istenen araç sistemde bulunamadı.";
                    return RedirectToAction("Araclar");
                }
                int count = db.KullaniciArac.Where(x => x.aracID == id && (x.kiraBaslangicTarih <= baslangic && x.kiraBitisTarih < bitis) && x.kiraBitisTarih < baslangic).Count();
                if (count > 0)
                {
                    Kullanici kul = (Kullanici)Session["Kullanici"];
                    KullaniciArac newData = new KullaniciArac()
                    {
                        kiraBaslangicTarih = baslangic,
                        kiraBitisTarih = bitis,
                        aracID = id,
                        tarih = DateTime.Now,
                        kullaniciID = kul.kullaniciID
                    };
                    db.KullaniciArac.Add(newData);
                    db.SaveChanges();

                    TempData["Mesaj"] = "Araç başarıyla kiralandı.";
                }
                else
                {
                    TempData["Mesaj"] = "Araç seçilen tarihlerde başkasına kiralanmıştır.";
                    return RedirectToAction("Araclar");
                }
                
            }
            catch (Exception e)
            {
                TempData["Mesaj"] = "Sebebi bilinmeyen bir hata meydana geldi.";
            }
            return RedirectToAction("Araclar");
        }
        public ActionResult Araclarim()
        {
            Kullanici kul = (Kullanici)Session["Kullanici"];
            if (kul == null)
            {
                return RedirectToAction("Anasayfa");
            }

            return View(db.KullaniciArac.Where(x => x.kullaniciID == kul.kullaniciID).ToList());
        }
        public ActionResult Cikis()
        {
            Session.Abandon();
            return RedirectToAction("Anasayfa");
        }


    }
}