using Microsoft.AspNet.Identity;
using RestaurantRestockPro.Models.Restaurant;
using RestaurantRestockPro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRestockPro.WebMVC.Controllers
{
    [Authorize]
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RestaurantService(userId);
            var model = service.GetRestaurants();
            
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RestaurantCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateRestaurantService();

            if (service.CreateRestaurant(model))
            {
                TempData["SaveResult"] = "A restaurant was Created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Restaurant could not be created.");
            return View("Model");
        }

        public ActionResult Details(int id)
        {
            var svc = CreateRestaurantService();
            var model = svc.GetRestaurantById(id);

            return View(model);
        }

        private RestaurantService CreateRestaurantService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RestaurantService(userId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateRestaurantService();
            var detail = service.GetRestaurantById(id);
            var model =
                new RestaurantEdit
                {
                    RestaurantId = detail.RestaurantId,
                    RestaurantName = detail.RestaurantName,
                    RestaurantLocation = detail.RestaurantLocation
                };
            return View(model);
        }
    }
}