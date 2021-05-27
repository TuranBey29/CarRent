namespace CarRent.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Arac")]
    public partial class Arac
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Arac()
        {
            KullaniciArac = new HashSet<KullaniciArac>();
        }

        public int aracID { get; set; }

        public int? aracModelID { get; set; }

        public int? aracSinifID { get; set; }

        [StringLength(10)]
        public string depozito { get; set; }

        [StringLength(10)]
        public string kmSinir { get; set; }

        public int? aracYakitTurID { get; set; }

        public int? aracVitesTurID { get; set; }

        public int? gunlukFiyat { get; set; }

        public bool? reklam { get; set; }

        [Column(TypeName = "text")]
        public string aracResim { get; set; }

        public bool? indirim { get; set; }

        public int? bulunduguYer { get; set; }

        public virtual AracModel AracModel { get; set; }

        public virtual AracSinif AracSinif { get; set; }

        public virtual AracVitesTur AracVitesTur { get; set; }

        public virtual AracYakitTur AracYakitTur { get; set; }

        public virtual Ilce Ilce { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KullaniciArac> KullaniciArac { get; set; }
    }
}
