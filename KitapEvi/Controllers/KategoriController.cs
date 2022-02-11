using KitapEvi_DataAcces.Data;
using KitapEvi_Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitapEvi.Controllers
{
    public class KategoriController : Controller
    {
        private readonly KitapEviContext _db;

        public KategoriController(KitapEviContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Kategori> klist = _db.Kategoriler.ToList();
            return View(klist);
        }

        public IActionResult Update_Insert(int? id)
        {
            Kategori obj = new Kategori();
            if (id == null)
            {
                return View(obj);    //bos gonder 
            }
            obj = _db.Kategoriler.FirstOrDefault(x => x.KategoriID == id);
            if (obj == null)
            {
                return NotFound();
            } 
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]//guvenlık amacıyla atılan ısteklerın gercek kısler tarafından gelenlere cevap vermesını  sağlar
        public IActionResult Update_Insert(Kategori obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.KategoriID == 0)
                {///creat
                    _db.Kategoriler.Add(obj);

                }
                else
                {
                    //update
                    _db.Kategoriler.Update(obj);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }
        public IActionResult Delete(int id)
        {//dolu gelmelı bısey yapmamalı

            var silinen = _db.Kategoriler.FirstOrDefault(x => x.KategoriID == id);
            _db.Kategoriler.Remove(silinen);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult CokluEkleme3()
        {
            List<Kategori> klist = new List<Kategori>();
            for (int i = 0; i < 3; i++)
            {
                klist.Add(new Kategori { KategoriAd = Guid.NewGuid().ToString() });
            }
            _db.Kategoriler.AddRange(klist);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult CokluEkleme10()
        {
            List<Kategori> klist = new List<Kategori>();
            for (int i = 0; i < 10; i++)
            {
                klist.Add(new Kategori { KategoriAd = Guid.NewGuid().ToString() });
            }
            _db.Kategoriler.AddRange(klist);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult CokluSilme3()
        {
            IEnumerable<Kategori> klist = _db.Kategoriler.OrderByDescending(x => x.KategoriID).Take(3).ToList(); //sondan 3tane al tersten sırala
            _db.Kategoriler.RemoveRange(klist);
            _db.SaveChanges();
            return RedirectToAction("Index");
        } 
        public IActionResult CokluSilme10()
        {
            IEnumerable<Kategori> klist = _db.Kategoriler.OrderByDescending(x => x.KategoriID).Take(3).ToList(); //sondan 3tane al tersten sırala
            _db.Kategoriler.RemoveRange(klist);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
