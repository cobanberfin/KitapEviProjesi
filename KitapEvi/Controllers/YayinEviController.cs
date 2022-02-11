using KitapEvi_DataAcces.Data;
using KitapEvi_Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitapEvi.Controllers
{
    public class YayinEviController : Controller
    {
        private readonly KitapEviContext _db;
        public YayinEviController(KitapEviContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Yayınevi> objlist = _db.Yayınevleri.ToList();
            return View(objlist);
        }
        public IActionResult Update_Insert(int? id)
        {
            Yayınevi obj = new Yayınevi();
            if (id == null)
            {
                return View(obj);
            }
            obj = _db.Yayınevleri.FirstOrDefault(x => x.YayıneviID == id);
            if (obj == null)
            {
                return NotFound();

            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update_Insert(Yayınevi obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.YayıneviID == 0)
                {
                    //create 
                    _db.Yayınevleri.Add(obj);
                }
                else
                {
                    //update
                    _db.Yayınevleri.Update(obj);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);
        }
        public IActionResult Delete(int id)
        {
            var obj = _db.Yayınevleri.FirstOrDefault(x => x.YayıneviID == id);
            _db.Yayınevleri.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
