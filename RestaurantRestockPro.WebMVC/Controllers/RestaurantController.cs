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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RestaurantEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.RestaurantId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateRestaurantService();

            if (service.UpdateRestaurant(model))
            {
                TempData["SaveResult"] = "The restaurant was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Restaurant could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRestaurantService();
            var model = svc.GetRestaurantById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateRestaurantService();
            service.DeleteRestaurant(id);
            TempData["SaveResult"] = "The restaurant was deleted.";
            return RedirectToAction("Index");
        }

        private RestaurantService CreateRestaurantService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RestaurantService(userId);
            return service;
        }
    }
}