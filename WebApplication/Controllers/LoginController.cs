using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using WebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class LoginController : Controller
    {
        private IDeliveryManManager DeliveryManManager { get; }
        private IPersonManager PersonManager { get; }
        public LoginController(IDeliveryManManager deliveryManManager, IPersonManager personManager)
        {
            DeliveryManManager = deliveryManManager;
            PersonManager = personManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var deliveryMan = DeliveryManManager.GetDeliveryMan(loginVM.Email, loginVM.Password);
                var person = PersonManager.GetPerson(loginVM.Email, loginVM.Password);

                if (deliveryMan != null)
                {
                    HttpContext.Session.SetInt32("IdDeliveryMan", deliveryMan.Id_Delivery);
                    return RedirectToAction("Index", "DeliveryMan");
                }
                if (person != null)
                {
                    HttpContext.Session.SetInt32("IdPerson", person.ID_person);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid email or password");
            }
            return View(loginVM);
        }
    }
}