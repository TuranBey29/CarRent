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
        public int ilceID { get; set; }

        public int? ilID { get; set; }

        [Column("ilce")]
        [StringLength(100)]
        public string ilce1 { get; set; }

        public virtual Il Il { get; set; }
    }
}
