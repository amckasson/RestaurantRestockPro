using RestaurantRestockPro.Models.Restaurant;
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
            var model = new RestaurantListItem[0];
            return View(model);
        }
    }
}