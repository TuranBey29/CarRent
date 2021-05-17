using CarRent.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRent.Controllers
{
    public class PanelController : Controller
    {
        CarRentContext db = new CarRentContext();
        // GET: Panel
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AracListe()
        {
            AnasayfaPageModel model = new AnasayfaPageModel()
            {
                Arac = db.Arac.ToList(),
                AracMarka = db.AracMarka.ToList(),
                AracModel = db.AracModel.ToList(),
                AracSinif = db.AracSinif.ToList(),
                AracVitesTur = db.AracVitesTur.ToList(),
                AracYakitTur = db.AracYakitTur.ToList()
            };
            return View(model);
        }
        public ActionResult AracEkle()
        {
            AnasayfaPageModel model = new AnasayfaPageModel()
            {
                Arac = db.Arac.ToList(),
                AracMarka = db.AracMarka.ToList(),
                AracModel = db.AracModel.ToList(),
                AracSinif = db.AracSinif.ToList(),
                AracVitesTur = db.AracVitesTur.ToList(),
                AracYakitTur = db.AracYakitTur.ToList()
            };

            return View(model);
        }

        public ActionResult AracDuzenle(Arac veri, HttpPostedFileBase aracResim)
        {
            try
            {
                Arac arac = db.Arac.Where(x => x.aracID == veri.aracID).FirstOrDefault();

                string aracResimString = null;
                if (aracResim != null)
                {
                    Guid resimAd = Guid.NewGuid();
                    string resimUzanti = "";
                    resimUzanti = System.IO.Path.GetExtension(aracResim.FileName);

                    if (resimUzanti != ".jpeg" && resimUzanti != ".png" && resimUzanti != ".jpg")
                    {
                        TempData["mesaj"] = "Sadece jpeg , png ve jpg yükleyebilirsiniz.";
                    }
                    else
                    {
                        string path = System.IO.Path.Combine(Server.MapPath("~/Content/images"), resimAd.ToString() + resimUzanti);

                        aracResim.SaveAs(path);
                    }

                    aracResimString = resimAd + resimUzanti;
                }

                

                arac.aracModelID = veri.aracModelID;
                arac.aracSinifID = veri.aracSinifID;
                arac.aracYakitTurID = veri.aracYakitTurID;
                arac.depozito = veri.depozito;
                arac.kmSinir = veri.kmSinir;
                arac.gunlukFiyat = veri.gunlukFiyat;
                arac.indirim = veri.indirim == null ? false : veri.indirim;
                arac.reklam = veri.reklam == null ? false : veri.reklam;
                arac.aracVitesTurID = veri.aracVitesTurID;
                if (aracResimString != null)
                {
                    arac.aracResim = aracResimString;
                }
                
                db.SaveChanges();
            }
            catch (Exception)
            {
                TempData["mesaj"] = "Veri Eklenirken sorun oluştu.";
            }

            return RedirectToAction("AracListe");
        }

        [HttpPost]
        public ActionResult AracEkle(Arac veri, HttpPostedFileBase aracResim)
        {
            try
            {
                Guid resimAd = Guid.NewGuid();
                string resimUzanti = "";
                if (aracResim != null)
                {
                    resimUzanti = System.IO.Path.GetExtension(aracResim.FileName);

                    if (resimUzanti != ".jpeg" && resimUzanti != ".png" && resimUzanti != ".jpg")
                    {
                        TempData["mesaj"] = "Sadece jpeg , png ve jpg yükleyebilirsiniz.";
                    }
                    else
                    {
                        string path = System.IO.Path.Combine(Server.MapPath("~/Content/images"), resimAd.ToString() + resimUzanti);

                        aracResim.SaveAs(path);
                    }

                    Arac arac = new Arac()
                    {
                        aracModelID = veri.aracModelID,
                        aracSinifID = veri.aracSinifID,
                        aracYakitTurID = veri.aracYakitTurID,
                        depozito = veri.depozito,
                        kmSinir = veri.kmSinir,
                        gunlukFiyat = veri.gunlukFiyat,
                        indirim = veri.indirim == null ? false : veri.indirim,
                        reklam = veri.reklam == null ? false : veri.reklam,
                        aracVitesTurID = veri.aracVitesTurID,
                        aracResim = resimAd + resimUzanti
                    };

                    db.Arac.Add(arac);
                    db.SaveChanges();

                    TempData["mesaj"] = "Araç Başarıyla Eklendi.";

                }
                else
                {
                    TempData["mesaj"] = "Resim Eklemek Zorundasınız.";
                }
            }
            catch (Exception)
            {
                TempData["mesaj"] = "Veri Eklenirken sorun oluştu.";
            }

            return RedirectToAction("AracEkle");
        }


        public ActionResult AracSil(int id)
        {
            try
            {
                db.Arac.Remove(db.Arac.FirstOrDefault(x => x.aracID == id));
                db.SaveChanges();

                TempData["mesaj"] = "Araç Başarıyla Silindi.";
                return RedirectToAction("AracListe");
            }
            catch (Exception)
            {
                TempData["mesaj"] = "Veri Eklerken Hata Meydana Geldi.";
                return RedirectToAction("AracListe");
            }

        }

        public ActionResult Sinif()
        {
            return View(db.AracSinif.ToList());
        }
        public ActionResult SinifEkle(string sinif)
        {
            try
            {
                AracSinif aracSinif = new AracSinif()
                {
                    sinif = sinif
                };

                db.AracSinif.Add(aracSinif);
                db.SaveChanges();

                TempData["mesaj"] = "Sınıf Başarıyla Eklendi.";

                return RedirectToAction("Sinif");

            }
            catch (Exception)
            {
                TempData["mesaj"] = "Veri Eklerken Hata Meydana Geldi.";
                return RedirectToAction("Sinif");
            }
        }

        public ActionResult SinifSil(int id)
        {
            try
            {
                db.AracSinif.Remove(db.AracSinif.FirstOrDefault(x => x.aracSinifID == id));
                db.SaveChanges();

                TempData["mesaj"] = "Sınıf Başarıyla Silindi.";

                return RedirectToAction("Sinif");
            }
            catch (Exception)
            {
                TempData["mesaj"] = "Veri Eklerken Hata Meydana Geldi.";
                return RedirectToAction("Sinif");
            }
        }

        public ActionResult SinifDuzenle(int id, string sinif)
        {
            try
            {
                AracSinif aracSinif = db.AracSinif.Where(x => x.aracSinifID == id).SingleOrDefault();

                aracSinif.sinif = sinif;

                db.SaveChanges();

                TempData["mesaj"] = "Sınıf Başarıyla Düzenlendi.";

                return RedirectToAction("Sinif");
            }
            catch (Exception)
            {
                TempData["mesaj"] = "Veri Eklerken Hata Meydana Geldi.";
                return RedirectToAction("Sinif");
            }
        }

        public ActionResult VitesTur()
        {
            return View(db.AracVitesTur.ToList());
        }
        public ActionResult VitesTurEkle(string vitesTur)
        {
            try
            {
                AracVitesTur aracVitesTur = new AracVitesTur()
                {
                    vitesTur = vitesTur
                };

                db.AracVitesTur.Add(aracVitesTur);
                db.SaveChanges();

                TempData["mesaj"] = "Tür Başarıyla Eklendi.";

                return RedirectToAction("VitesTur");

            }
            catch (Exception)
            {
                TempData["mesaj"] = "Veri Eklerken Hata Meydana Geldi.";
                return RedirectToAction("VitesTur");
            }
        }

        public ActionResult VitesTurSil(int id)
        {
            try
            {
                db.AracVitesTur.Remove(db.AracVitesTur.FirstOrDefault(x => x.aracVitesTurID == id));
                db.SaveChanges();

                TempData["mesaj"] = "Tür Başarıyla Silindi.";

                return RedirectToAction("VitesTur");
            }
            catch (Exception)
            {
                TempData["mesaj"] = "Veri Eklerken Hata Meydana Geldi.";
                return RedirectToAction("VitesTur");
            }
        }

        public ActionResult VitesTurDuzenle(int id, string vitesTur)
        {
            try
            {
                AracVitesTur aracVitesTur = db.AracVitesTur.Where(x => x.aracVitesTurID == id).SingleOrDefault();

                aracVitesTur.vitesTur = vitesTur;

                db.SaveChanges();

                TempData["mesaj"] = "Tür Başarıyla Düzenlendi.";

                return RedirectToAction("VitesTur");
            }
            catch (Exception)
            {
                TempData["mesaj"] = "Veri Eklerken Hata Meydana Geldi.";
                return RedirectToAction("VitesTur");
            }
        }

        public ActionResult YakitTur()
        {
            return View(db.AracYakitTur.ToList());
        }
        public ActionResult YakitTurEkle(string yakitTur)
        {
            try
            {
                AracYakitTur aracYakitTur = new AracYakitTur()
                {
                    tur = yakitTur
                };

                db.AracYakitTur.Add(aracYakitTur);
                db.SaveChanges();

                TempData["mesaj"] = "Tür Başarıyla Eklendi.";

                return RedirectToAction("YakitTur");

            }
            catch (Exception)
            {
                TempData["mesaj"] = "Veri Eklerken Hata Meydana Geldi.";
                return RedirectToAction("YakitTur");
            }
        }

        public ActionResult YakitTurSil(int id)
        {
            try
            {
                db.AracYakitTur.Remove(db.AracYakitTur.FirstOrDefault(x => x.aracYakitTurID == id));
                db.SaveChanges();

                TempData["mesaj"] = "Tür Başarıyla Silindi.";

                return RedirectToAction("YakitTur");
            }
            catch (Exception)
            {
                TempData["mesaj"] = "Veri Eklerken Hata Meydana Geldi.";
                return RedirectToAction("YakitTur");
            }
        }

        public ActionResult YakitTurDuzenle(int id, string yakitTur)
        {
            try
            {
                AracYakitTur aracYakitTur = db.AracYakitTur.Where(x => x.aracYakitTurID == id).SingleOrDefault();

                aracYakitTur.tur = yakitTur;

                db.SaveChanges();

                TempData["mesaj"] = "Tür Başarıyla Düzenlendi.";

                return RedirectToAction("YakitTur");
            }
            catch (Exception)
            {
                TempData["mesaj"] = "Veri Eklerken Hata Meydana Geldi.";
                return RedirectToAction("YakitTur");
            }
        }

        public ActionResult SiteAyar()
        {
            return View(db.SiteAyar.FirstOrDefault());
        }

        public ActionResult SiteAyarDuzenle(SiteAyar veri)
        {
            try
            {
                SiteAyar siteAyar = db.SiteAyar.FirstOrDefault();

                siteAyar.hakkimdaYazi = veri.hakkimdaYazi;
                siteAyar.footerYazi = veri.footerYazi;
                siteAyar.hakkimdaDurum = veri.hakkimdaDurum == null ? false : veri.hakkimdaDurum;
                siteAyar.indirimDurum = veri.indirimDurum == null ? false : veri.indirimDurum;
                siteAyar.populerArabaDurum = veri.populerArabaDurum == null ? false : veri.populerArabaDurum;

                db.SaveChanges();

                TempData["mesaj"] = "Ayar Başarıyla Düzenlendi.";

                return RedirectToAction("SiteAyar");
            }
            catch (Exception)
            {
                TempData["mesaj"] = "Veri Eklerken Hata Meydana Geldi.";
                return RedirectToAction("YakitTur");
            }

        }
    }

}