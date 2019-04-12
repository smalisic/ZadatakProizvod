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