using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KitapEvi_Models.Models
{[Table("tb_Kitap")]//yazmazsak kıtap dıye gelır ısmı
  public  class Kitap
    {
        public int KitapID { get; set; }
        [Required]
        public string KitapAdi { get; set; }
        [Required]
        public double Fiyat { get; set; }
        [Required,MaxLength(13)]
        public string ISBN { get; set; }
        [NotMapped]  //verıtabanına yansıtma
        public double İndirimlifiyat { get; set; }
        [ForeignKey("Kategori")]
        public int? KategoriID { get; set; }
        public Kategori Kategori { get; set; }

        [ForeignKey("Yayınevi")]
        public int YayıneviID { get; set; }
        public Yayınevi Yayınevi { get; set; }
        public int? KitapDetayID { get; set; }
        public KitapDetay KitapDetay { get; set; }
        public ICollection<KitapİYazar> KitapİYazarlar { get; set; }
    }
}
