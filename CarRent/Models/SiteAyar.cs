namespace CarRent.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SiteAyar")]
    public partial class SiteAyar
    {
        public int siteAyarID { get; set; }

        public bool? hakkimdaDurum { get; set; }

        [Column(TypeName = "text")]
        public string hakkimdaYazi { get; set; }

        public bool? indirimDurum { get; set; }

        public bool? populerArabaDurum { get; set; }

        [Column(TypeName = "text")]
        public string footerYazi { get; set; }
    }
}
