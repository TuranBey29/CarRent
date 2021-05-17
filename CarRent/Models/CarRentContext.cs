namespace CarRent.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CarRentContext : DbContext
    {
        public CarRentContext()
            : base("name=CarRentContext")
        {
        }

        public virtual DbSet<Arac> Arac { get; set; }
        public virtual DbSet<AracMarka> AracMarka { get; set; }
        public virtual DbSet<AracModel> AracModel { get; set; }
        public virtual DbSet<AracSinif> AracSinif { get; set; }
        public virtual DbSet<AracVitesTur> AracVitesTur { get; set; }
        public virtual DbSet<AracYakitTur> AracYakitTur { get; set; }
        public virtual DbSet<Il> Il { get; set; }
        public virtual DbSet<Ilce> Ilce { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<KullaniciYetki> KullaniciYetki { get; set; }
        public virtual DbSet<SiteAyar> SiteAyar { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Yetki> Yetki { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arac>()
                .Property(e => e.aracResim)
                .IsUnicode(false);

            modelBuilder.Entity<Kullanici>()
                .Property(e => e.adres)
                .IsUnicode(false);

            modelBuilder.Entity<SiteAyar>()
                .Property(e => e.hakkimdaYazi)
                .IsUnicode(false);

            modelBuilder.Entity<SiteAyar>()
                .Property(e => e.footerYazi)
                .IsUnicode(false);
        }
    }
}
