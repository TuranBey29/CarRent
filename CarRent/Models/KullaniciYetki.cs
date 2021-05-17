namespace CarRent.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KullaniciYetki")]
    public partial class KullaniciYetki
    {
        public int kullaniciYetkiID { get; set; }

        public int? kullaniciID { get; set; }

        public int? yetkiID { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual Yetki Yetki { get; set; }
    }
}
