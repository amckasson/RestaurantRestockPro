﻿using System;
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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RestockService(userId);

            service.CreateRestock(model);

            return RedirectToAction("Index");
        }
    }
}