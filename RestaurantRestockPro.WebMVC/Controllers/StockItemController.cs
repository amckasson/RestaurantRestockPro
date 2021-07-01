using RestaurantRestockPro.Models.StockItem;
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
            var model = new StockItemListItem[0];
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}