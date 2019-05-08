using Dogtastic.Data;
using Dogtastic.Models;
using DogtasticData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dogtastic.Controllers
{
    public class DogController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Dogs
        public ActionResult Index()
        {
            return View(_db.Dogs.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dog dog)
        {
            if (ModelState.IsValid)
            {
                _db.Dogs.Add(dog);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dog);
        }
    }
}
