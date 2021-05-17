namespace CarRent.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kullanici")]
    public partial class Kullanici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kullanici()
        {
            KullaniciYetki = new HashSet<KullaniciYetki>();
        }

        public int kullaniciID { get; set; }

        [StringLength(50)]
        public string ad { get; set; }

        [StringLength(50)]
        public string soyad { get; set; }

        [StringLength(30)]
        public string eposta { get; set; }

        [StringLength(10)]
        public string sifre { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dogumTarihi { get; set; }

        [StringLength(11)]
        public string tcKimlik { get; set; }

        [StringLength(50)]
        public string telefonNumarasi { get; set; }

        [StringLength(50)]
        public string sehir { get; set; }

        [Column(TypeName = "text")]
        public string adres { get; set; }

        public DateTime? kayitTarih { get; set; }

        public bool? uyelikDurum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KullaniciYetki> KullaniciYetki { get; set; }
    }
}
