using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<AddRestaurant> Restaurants = db.Restaurants.ToList();
            return View(Restaurants);
        }

        public ActionResult About(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            AddRestaurant restaurant = db.Restaurants.Where(r => r.Id == id).FirstOrDefault();

            ViewBag.Message = "Your application description page.";

            return View(restaurant);
        }

        public ActionResult Create()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Create(string Name, string Cuisine, int Rating)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            AddRestaurant restaurant = new AddRestaurant() { Name = Name, Cuisine = Cuisine, Rating = Rating };
            db.Restaurants.Add(restaurant);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            AddRestaurant restaurant = db.Restaurants.Where(r => r.Id == id).FirstOrDefault();

            return View(restaurant);
        }
        [HttpPost]
        public ActionResult Edit(string Name, string Cuisine, int Rating)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            AddRestaurant restaurant = db.Restaurants.Where(r => r.Name == Name).FirstOrDefault();
            //restaurant.Id = Id;
            restaurant.Name = Name;
            restaurant.Cuisine = Cuisine;
            restaurant.Rating = Rating;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id) 
        {
            ApplicationDbContext db = new ApplicationDbContext();
            AddRestaurant restaurant = db.Restaurants.Where(r => r.Id == id).FirstOrDefault();
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}