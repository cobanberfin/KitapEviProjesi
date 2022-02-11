using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KitapEvi_Models.Models
{[Table("tb_Kategori")]
   public class Kategori
    {//table data annotations :Veri tabanına tablo adını duznlemek için kullanılır
        //column annotations :vt de yer alan tablo içindekı kolon adını değiştirmek için kullanılır
        public int KategoriID { get; set; }
        [Column("Ad")]
        [Required(ErrorMessage ="Bu alan boş geçilemez")]
        public string KategoriAd { get; set; }
        public List<Kitap>Kitap { get; set; }

    }
}
