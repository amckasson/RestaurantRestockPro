using Microsoft.AspNet.Identity;
using RestaurantRestockPro.Models.StockOrder;
using RestaurantRestockPro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRestockPro.WebMVC.Controllers
{
    [Authorize]
    public class StockOrderController : Controller
    {
        // GET: StockOrder
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StockOrderService(userId);
            var model = service.GetStockOrders();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StockOrderCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            
            var service = CreateStockOrderService();

            if (service.CreateStockOrder(model)) 
            {
                TempData["SaveResult"] = "Stock order was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Stock order could not be created.");
            return View("model");
        }

        public ActionResult Details(int id)
        {
            var svc = CreateStockOrderService();
            var model = svc.GetStockOrderById(id);
            return View(model);
        }

        private StockOrderService CreateStockOrderService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StockOrderService(userId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateStockOrderService();
            var detail = service.GetStockOrderById(id);
            var model =
                new StockOrderEdit
                {
                    StockOrderId = detail.StockOrderId,
                    Manager = detail.Manager
                };
            return View(model);
        }
    }
}