using System;
using RestaurantRestockPro.Models.Restock;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantRestockPro.Services;
using Microsoft.AspNet.Identity;

namespace RestaurantRestockPro.WebMVC.Controllers
{
    [Authorize]
    public class RestockController : Controller
    {
        // GET: Restock
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RestockService(userId);
            var model = service.GetRestock();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RestockCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            
            var service = CreateRestockService();

            if (service.CreateRestock(model))
            {
                TempData["SaveResult"] = "Restock was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Restock could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateRestockService();
            var model = svc.GetRestockById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateRestockService();
            var detail = service.GetRestockById(id);
            var model = new RestockDetail
            {
                RestockId = detail.RestockId,
                Quantity = detail.Quantity,
                StockOrderId = detail.StockOrderId,
                StockItemId = detail.StockItemId
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RestockDetail model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.RestockId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateRestockService();

            if (service.UpdateRestock(model))
            {
                TempData["SaveResult"] = "Restock was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Restock could not be updated.");
            return View(model);
        }

        private RestockService CreateRestockService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RestockService(userId);
            return service;
        }
    }
}