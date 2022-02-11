using KitapEvi_DataAcces.Data;
using KitapEvi_Models.Models;
using KitapEvi_Models.Models.ViewsModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitapEvi.Controllers
{
    public class KitapController : Controller
    {
        private readonly KitapEviContext _db;
        public KitapController(KitapEviContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //List<Kitap> klist = _db.Kitaplar.ToList();
            //foreach (var item in klist)
            //{// uygulanır ama verımlı değil.herbır kıtap kaydı ıcın sureklı sorgu atar daha hızlı olması ıcın explictloading kullanıyorum yayınevı bılgısıbosgelıyor burda baglantıkurup iteme onu aldm
            //    item.Yayınevi = _db.Yayınevleri.FirstOrDefault(x => x.YayıneviID == item.YayıneviID);

            //}
            List<Kitap> klist = _db.Kitaplar.Include(x => x.Yayınevi).ToList();
            //ilgili alanlara innerjoın(ilişkili)yaparal getırır
            return View(klist);
        }
        public IActionResult Update_Insert(int? id)
        {
            KitapVm obj = new KitapVm();
            obj.Yayinevilistesi = _db.Yayınevleri.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem//dropdown list olustrudm
            {
                Text = x.YayıneviAdi,
                Value = x.YayıneviID.ToString()
            });
            if (id == null)
            {
                return View(obj);
            }
            //düzenleme
            obj.Kitap = _db.Kitaplar.FirstOrDefault(x => x.KitapID == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update_Insert(KitapVm kitapVm )
        {
            if (kitapVm.Kitap.KitapID == 0)
            {
                _db.Kitaplar.Add(kitapVm.Kitap);
            }
            else
            {
                _db.Kitaplar.Update(kitapVm.Kitap);
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var silinen = _db.Kitaplar.FirstOrDefault(x => x.KitapID == id);
            _db.Kitaplar.Remove(silinen);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Detaylar(int? id)
        {
            KitapVm obj = new KitapVm();
            if (id == null)
            {
                return View(obj);
            }
            //duzenleme
            obj.Kitap = _db.Kitaplar.FirstOrDefault(x => x.KitapID == id);//sadece kitap
            obj.Kitap.KitapDetay = _db.KitapDetaylar.FirstOrDefault(x => x.KitapID == id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Detaylar(KitapVm obj)
        {
            if (obj.Kitap.KitapDetay.KitapID == 0)
            {
                //creat
                var kitapdb = _db.Kitaplar.FirstOrDefault(x => x.KitapID == obj.Kitap.KitapID);//hangı kıtap buldm
                obj.Kitap.KitapDetay.KitapID = kitapdb.KitapID;
                _db.KitapDetaylar.Add(obj.Kitap.KitapDetay);
                _db.SaveChanges();

                kitapdb.KitapDetayID = obj.Kitap.KitapDetay.KitapDetayId;
                _db.SaveChanges();


            }
            else
            {
                //update
                _db.KitapDetaylar.Update(obj.Kitap.KitapDetay);
            }
            return RedirectToAction("Index");



        }
    }
}
