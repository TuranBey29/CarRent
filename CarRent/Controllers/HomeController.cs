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
    }
}