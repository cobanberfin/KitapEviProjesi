using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KitapEvi_Models.Models
{[Table("tb_Yayınevi")]
  public  class Yayınevi
    {
        public int YayıneviID { get; set; }
        [Required]
        public string YayıneviAdi { get; set; }
        public string Lokasyon { get; set; }
      public List<Kitap> Kitaplar { get; set; }

    }
}
