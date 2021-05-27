namespace CarRent.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KullaniciArac")]
    public partial class KullaniciArac
    {
        public int kullaniciAracID { get; set; }

        public int? aracID { get; set; }

        public int? kullaniciID { get; set; }

        public DateTime? kiraBaslangicTarih { get; set; }

        public DateTime? kiraBitisTarih { get; set; }

        public DateTime? tarih { get; set; }

        public virtual Arac Arac { get; set; }

        public virtual Kullanici Kullanici { get; set; }
    }
}
