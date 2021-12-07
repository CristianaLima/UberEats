﻿using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    public class RestaurantsController : Controller
    {
        private IRestaurantManager RestaurantManager;

        public RestaurantsController(IRestaurantManager restaurantManager)
        {
            RestaurantManager = restaurantManager;
        }
        // GET: RestaurantsController
        public ActionResult Index()
        {
            if(HttpContext.Session.GetInt32("IdDeliveryMan") == null)
            {
                if (HttpContext.Session.GetInt32("IdPerson") == null)
                    return RedirectToAction("Index", "Login");
            }

            var restaurants = RestaurantManager.GetRestaurants();
            return View(restaurants);
        }

        // GET: RestaurantsController/Details/5
        public ActionResult Details(int id)
        {
            if (HttpContext.Session.GetInt32("IdDeliveryMan") == null)
            {
                if (HttpContext.Session.GetInt32("IdPerson") == null)
                    return RedirectToAction("Index", "Login");
            }
            return View();
        }

        // GET: RestaurantsController/Create
        public ActionResult Create()
        {
            if (HttpContext.Session.GetInt32("IdDeliveryMan") == null)
            {
                if (HttpContext.Session.GetInt32("IdPerson") == null)
                    return RedirectToAction("Index", "Login");
            }
            return View();
        }

        // POST: RestaurantsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            if (HttpContext.Session.GetInt32("IdDeliveryMan") == null)
            {
                if (HttpContext.Session.GetInt32("IdPerson") == null)
                    return RedirectToAction("Index", "Login");
            }
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RestaurantsController/Edit/5
        public ActionResult Edit(int id)
        {
            if (HttpContext.Session.GetInt32("IdDeliveryMan") == null)
            {
                if (HttpContext.Session.GetInt32("IdPerson") == null)
                    return RedirectToAction("Index", "Login");
            }
            var restaurant = RestaurantManager.GetRestaurantID(id);
            return View(restaurant);
        }

        // POST: RestaurantsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DTO.Restaurant r)
        {
            if (HttpContext.Session.GetInt32("IdDeliveryMan") == null)
            {
                if (HttpContext.Session.GetInt32("IdPerson") == null)
                    return RedirectToAction("Index", "Login");
            }
            try
            {
                RestaurantManager.ModifyAllRestaurant(r);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(r);
            }
        }

        // GET: RestaurantsController/Delete/5
        public ActionResult Delete(int id)
        {
            if (HttpContext.Session.GetInt32("IdDeliveryMan") == null)
            {
                if (HttpContext.Session.GetInt32("IdPerson") == null)
                    return RedirectToAction("Index", "Login");
            }
            return View();
        }

        // POST: RestaurantsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (HttpContext.Session.GetInt32("IdDeliveryMan") == null)
            {
                if (HttpContext.Session.GetInt32("IdPerson") == null)
                    return RedirectToAction("Index", "Login");
            }
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}