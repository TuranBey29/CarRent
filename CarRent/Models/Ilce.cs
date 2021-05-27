namespace CarRent.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ilce")]
    public partial class Ilce
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ilce()
        {
            Arac = new HashSet<Arac>();
        }

        public int ilceID { get; set; }

        public int? ilID { get; set; }

        [Column("ilce")]
        [StringLength(100)]
        public string ilce1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Arac> Arac { get; set; }

        public virtual Il Il { get; set; }
    }
}
