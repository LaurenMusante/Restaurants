using Microsoft.AspNetCore.Mvc;
using Restaurants.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Restaurants.Controllers 
{
    public class CuisinesController : Controller
    {
        private readonly RestaurantsContext _db;

        public CuisinesController(RestaurantsContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Cuisine> model = _db.Cuisines.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cuisine Cuisine)
        {
            _db.Cuisines.Add(Cuisine);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Cuisine thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
            return View(thisCuisine);
        }

        public ActionResult Edit(int id)
        {
            var thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
            return View(thisCuisine);
        }

        [HttpPost]
        public ActionResult Edit(Cuisine cuisine)
        {
            _db.Entry(cuisine).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
            return View(thisCuisine);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
            _db.Cuisines.Remove(thisCuisine);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }    
}