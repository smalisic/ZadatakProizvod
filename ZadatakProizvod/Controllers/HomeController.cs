using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZadatakProizvod.Models;

namespace ZadatakProizvod.Controllers
{
    public class HomeController : Controller
    {
        private ProizvodiBazaEntities _db = new ProizvodiBazaEntities();

        public ActionResult Index()
        {
            return View(_db.Proizvodi.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Exclude ="Id")]Proizvod proizvodToCreate)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _db.Proizvodi.Add(proizvodToCreate);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var proizvodToEdit = (from m in _db.Proizvodi where m.Id == id select m).First();

            return View(proizvodToEdit);
        }
        [HttpPost]
        public ActionResult Edit(Proizvod proizvodToEdit)
        {
            var originalProizvod= (from m in _db.Proizvodi where m.Id == proizvodToEdit.Id select m).First();

            if (!ModelState.IsValid)
            {
                return View(originalProizvod);
            }

            _db.Entry(originalProizvod).CurrentValues.SetValues(proizvodToEdit);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            using (_db)
            {
                return View(_db.Proizvodi.Where(x=>x.Id==id).FirstOrDefault());
            }
        }
        
        public ActionResult Delete(int id)
        {
            using (_db)
            {
                return View(_db.Proizvodi.Where(x => x.Id == id).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using (_db)
            {
                var Proizvod=_db.Proizvodi.Where(x => x.Id == id).FirstOrDefault();

                _db.Proizvodi.Remove(Proizvod);
                _db.SaveChanges();

                return RedirectToAction("Index");

            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}