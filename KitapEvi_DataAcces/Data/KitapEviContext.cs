using KitapEvi_Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitapEvi_DataAcces.Data
{
  public  class KitapEviContext:DbContext
    {
        public KitapEviContext(DbContextOptions<KitapEviContext>options):base(options) //startuptanıla
        {

        }
        public DbSet<Tur> Turler { get; set; }
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Yazar> Yazarlar { get; set; }
        public DbSet<Yayınevi> Yayınevleri { get; set; }
        public DbSet<KitapDetay> KitapDetaylar { get; set; }
        public DbSet<KitapİYazar> KitapYazarlar { get; set; }
        //bırıncılanahtarolmasınııstıyorum
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //fluent api ile confıgırasyon işlemı yapmam gerekComposite key oluşturmak için:

            modelBuilder.Entity<KitapİYazar>().HasKey(x => new { x.YazarID, x.KitapID });//ikisinide birincil anahtar yaptım
        }
    }
}
