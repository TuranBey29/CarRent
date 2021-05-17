using CarRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRent
{
    public class AnasayfaPageModel
    {
        public List<Arac> Arac { get; set; }
        public List<AracModel> AracModel { get; set; }
        public List<AracMarka> AracMarka { get; set; }
        public List<AracSinif> AracSinif { get; set; }
        public List<AracVitesTur> AracVitesTur { get; set; }
        public List<AracYakitTur> AracYakitTur { get; set; }
        public SiteAyar SiteAyar { get; set; }
    }
}