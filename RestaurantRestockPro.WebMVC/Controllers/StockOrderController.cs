using RestaurantRestockPro.Models.StockOrder;
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
            var model = new StockOrderListItem[0];
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}