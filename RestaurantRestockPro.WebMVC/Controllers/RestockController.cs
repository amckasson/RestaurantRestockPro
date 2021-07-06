﻿using System;
using RestaurantRestockPro.Models.Restock;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRestockPro.WebMVC.Controllers
{
    [Authorize]
    public class RestockController : Controller
    {
        // GET: Restock
        public ActionResult Index()
        {
            var model = new RestockListItem[0];
            return View(model);
        }
    }
}