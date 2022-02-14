using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitapEvi_Models.Models.ViewsModel
{
  public  class KitapVm
    {
        public Kitap Kitap { get; set; }
        public IEnumerable<SelectListItem> Kategorilistesi { get; set; }
        public IEnumerable<SelectListItem> Yayinevilistesi{ get; set; }//dropdownılelısteyı lamakiçin 
    }
}
