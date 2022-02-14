using KitapEvi_DataAcces.Data;
using KitapEvi_Models.Models;
using KitapEvi_Models.Models.ViewsModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        {//yayını evını getırmek ıcın
            //List<Kitap> klist = _db.Kitaplar.ToList();
            //foreach (var item in klist)
            //{// uygulanır ama verımlı değil.herbır kıtap kaydı ıcın sureklı sorgu atar daha hızlı olması ıcın explictloading kullanıyorum yayınevı bılgısıbosgelıyor burda baglantıkurup iteme onu aldm
            //    item.Yayınevi = _db.Yayınevleri.FirstOrDefault(x => x.YayıneviID == item.YayıneviID);

            //}
            List<Kitap> klist = _db.Kitaplar.Include(x => x.Yayınevi).ToList();

            //ilgili alanlara innerjoın(ilişkili)yaparal getırır
            //foreach (var item in klist)
            //{
            //    item.Kategori = _db.Kategoriler.FirstOrDefault(X => X.KategoriID == item.KategoriID);//kategoriler sayfada gozukur
            //}
            //2.yol 
            klist = _db.Kitaplar.Include(x => x.Kategori).ToList();
            return View(klist);
            
        }
        public IActionResult Update_Insert(int? id)
        {
            KitapVm obj = new KitapVm();
            obj.Yayinevilistesi = _db.Yayınevleri.Select(x => new SelectListItem//dropdown list olustrudm
            {
                Text = x.YayıneviAdi,
                Value = x.YayıneviID.ToString()
            });
            obj.Kategorilistesi = _db.Kategoriler.Select(x => new SelectListItem
            {
                Text = x.KategoriAd,
                Value = x.KategoriID.ToString()
            });
            if (id == null)
            {
                return View(obj);
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
                var kitap = _db.Kitaplar.FirstOrDefault(x => x.KitapID == obj.Kitap.KitapID);
                obj.Kitap.KitapDetay.KitapDetayId = kitap.KitapID; 
                _db.KitapDetaylar.Update(obj.Kitap.KitapDetay);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");



        }
    }
}
