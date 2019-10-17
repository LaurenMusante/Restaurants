using Microsoft.AspNetCore.Mvc;
using Restaurants.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Restaurants.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly RestaurantsContext _db;

        public RestaurantsController(RestaurantsContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Restaurant> model = _db.Restaurants.Include(restaurant => restaurant.Cuisine).ToList(); //We can utilize eager loading by using Entity's built-in Include() methodThis basically states the following: for each Item in the database, include the Category it belongs to and then put all the Items into list.
            return View(model);
        }


        public ActionResult Create()
        {
            ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Restaurant restaurant)
        {
            _db.Restaurants.Add(restaurant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.Id == id);
            //^This is our way of communicating to the database, giving it the id that was passed in and telling the database to give us the item in the database that has this id. In this line, "items" is not a special name.
            return View(thisRestaurant);
        }
        // public ActionResult Edit(int id)
        // {
        //     var thisItem = _db.Items.FirstOrDefault(items => items.ItemId == id);
        //     ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
        //     return View(thisItem);
        // }

        // [HttpPost]
        // public ActionResult Edit(Item item)
        // {
        //     _db.Entry(item).State = EntityState.Modified;
        //     _db.SaveChanges();
        //     return RedirectToAction("Index");
        // }
        // public ActionResult Delete(int id)
        // {
        //     var thisItem = _db.Items.FirstOrDefault(items => items.ItemId == id);
        //     return View(thisItem);
        // }

        // [HttpPost, ActionName("Delete")]
        // public ActionResult DeleteConfirmed(int id)
        // {
        //     var thisItem = _db.Items.FirstOrDefault(items => items.ItemId == id);
        //     _db.Items.Remove(thisItem);
        //     _db.SaveChanges();
        //     return RedirectToAction("Index");
        // }

    }
}