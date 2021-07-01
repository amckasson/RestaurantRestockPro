using Microsoft.AspNet.Identity;
using RestaurantRestockPro.Models.StockItem;
using RestaurantRestockPro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRestockPro.WebMVC.Controllers
{
    [Authorize]
    public class StockItemController : Controller
    {
        // GET: StockItem
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StockItemService(userId);
            var model = service.GetStockItems();
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StockItemCreate model)
        {
            if (!ModelState.IsValid) return View(model);
           
            var service = CreateStockItemService();

            if (service.CreateStockItem(model)) 
            {
                TempData["SaveResult"] = "Stock item was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Stock item could not be created.");

            return View(model);
        }

        private StockItemService CreateStockItemService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StockItemService(userId);
            return service;
        }
    }
}