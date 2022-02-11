using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KitapEvi_Models.Models
{
   public class Yazar
    {
        public int YazarID { get; set; }
        [Required]
        public string YazarAd { get; set; }
        [Required]
        public string YazarSoyad{ get; set; }
        public string Lokasyon{ get; set; }
        public DateTime Dogumtarihi { get; set; }
        [NotMapped]
        public  string AdSoyad { get { return $"{YazarAd}  {YazarSoyad}  "; }  }
    }
}
