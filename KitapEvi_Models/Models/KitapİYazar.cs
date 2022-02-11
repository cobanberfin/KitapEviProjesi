﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KitapEvi_Models.Models
{
   public class KitapİYazar
    {//çoka-cok ilişkili tablo
        [ForeignKey("Kitap")]
        public int KitapID { get; set; }
        [ForeignKey("Yazar")]
        public int YazarID { get; set; }
        public Kitap Kitap { get; set; }
        public Yazar Yazar { get; set; }
    }
}
