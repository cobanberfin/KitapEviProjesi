using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KitapEvi_Models.Models
{
   public class KitapDetay
    {
        public int KitapDetayId { get; set; }
        public int BolumSayisi { get; set; }
        public int KitapSayfasi { get; set; }
        public int Agirlik { get; set; }
        [ForeignKey("Kitap")]
        public int KitapID { get; set; }
        public Kitap Kitap{ get; set; }//kitapla ilşkisi
    }
}
