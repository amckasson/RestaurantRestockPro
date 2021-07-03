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

        public ActionResult Details(int id)
        {
            var svc = CreateStockItemService();
            var model = svc.GetStockItemById(id);
            return View(model);
        }
        
        public ActionResult Edit(int id)
        {
            var service = CreateStockItemService();
            var detail = service.GetStockItemById(id);
            var model =
                new StockItemEdit
                {
                    StockItemId = detail.StockItemId,
                    Name = detail.Name,
                    Price = detail.Price,
                    IsFood = detail.IsFood
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StockItemEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.StockItemId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }

            var service = CreateStockItemService();

            if (service.UpdateStockItem(model))
            {
                TempData["SaveResult"] = "The stock item was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The stock item could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateStockItemService();
            var model = svc.GetStockItemById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateStockItemService();
            service.DeleteStockItem(id);
            TempData["SaveResult"] = "The stock item was deleted.";
            return RedirectToAction("Index");
        }

        private StockItemService CreateStockItemService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StockItemService(userId);
            return service;
        }
    }
}