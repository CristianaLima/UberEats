using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using WebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTO;

namespace WebApplication.Controllers
{
    public class LoginController : Controller
    {
        private IDeliveryManManager DeliveryManManager { get; }
        private IPersonManager PersonManager { get; }
        private ILocationManager LocationManager { get; }
        public LoginController(IDeliveryManManager deliveryManManager, IPersonManager personManager, ILocationManager locationManager)
        {
            DeliveryManManager = deliveryManManager;
            PersonManager = personManager;
            LocationManager = locationManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Choice()
        {
            return View();
        }
        public IActionResult AddDeliveryMan()
        {
            return View();
        }
        public IActionResult AddPerson()
        {
            return View();
        }
        public IActionResult AccountDeliveryMan()
        {
            // get des informations de la session actuelle
            // informations sur le compte 
            int accountID = (int)HttpContext.Session.GetInt32("IdDeliveryMan");
            DeliveryMan deliveryMan = DeliveryManManager.GetDeliveryManID(accountID);
            AccountVM accountVM = new AccountVM();
            accountVM.Address = deliveryMan.AddressDelivery;
            accountVM.BirthDate = deliveryMan.BirthDateDelivery;
            accountVM.Email = deliveryMan.EmailDelivery;
            accountVM.FirstName = deliveryMan.FirstNameDelivery;
            accountVM.Name = deliveryMan.NameDelivery;
            accountVM.Password = deliveryMan.PasswordDelivery;
            accountVM.PhoneNumber = deliveryMan.PhoneNumberDelivery;

            // informations sur la location
            Location location = LocationManager.GetLocationID(deliveryMan.ID_Location);
            accountVM.City = location.City;
            accountVM.NPA = location.NPA;
            Location workLocation = LocationManager.GetLocationID(deliveryMan.ID_workLocation);
            accountVM.WorkCity = workLocation.City;
            accountVM.WorkNPA = workLocation.NPA;

            return View(accountVM);
        }

        public IActionResult Account()
        {
            // get des informations de la session actuelle
            // informations sur le compte 
            int accountID = (int)HttpContext.Session.GetInt32("IdPerson");
            Person person = PersonManager.GetPersonID(accountID);
            AccountVM accountVM = new AccountVM();
            accountVM.Address = person.Address;
            accountVM.BirthDate = person.BirthDate;
            accountVM.Email = person.MailAddress;
            accountVM.FirstName = person.FirstName;
            accountVM.Name = person.Name;
            accountVM.Password = person.PasswordLogin;
            accountVM.PhoneNumber = person.PhoneNumber;

            // informations sur la location
            Location location = LocationManager.GetLocationID(person.ID_location);
            accountVM.City = location.City;
            accountVM.NPA = location.NPA;
           
            return View(accountVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(LoginVM loginVM)
        {
            //voit si toutes les informations son bien mises
            if (ModelState.IsValid)
            {
                //va chercher le livreur et la personne
                var deliveryMan = DeliveryManManager.GetDeliveryMan(loginVM.Email, loginVM.Password);
                var person = PersonManager.GetPerson(loginVM.Email, loginVM.Password);

                //mais dans la session la personne ou le livreur
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddDeliveryMan(AccountVM accountVM)
        {
            //voit si toutes les informations son bien mises
            if (ModelState.IsValid)
            {
                //verifie que la Location soit correcte
                var idLocation = LocationManager.GetLocationNPACity(accountVM.NPA, accountVM.City);
                if (idLocation == 0)
                {
                    ModelState.AddModelError("NPA", "le NPA ou la ville est incorrect");
                    return View();
                }
                var location = LocationManager.GetLocationID(idLocation);

                //verifie que la WorkLocation soit correcte
                var idWorkLocation = LocationManager.GetLocationNPACity(accountVM.WorkNPA, accountVM.WorkCity);
                if (idWorkLocation == 0)
                {
                    ModelState.AddModelError("WorkNPA", "le NPA ou la ville est incorrect");
                    return View();
                }
                var workLocation = LocationManager.GetLocationID(idWorkLocation);

                // Ajout données deliveryMan
                DeliveryMan deliveryMan = new DeliveryMan();
                deliveryMan.AddressDelivery = accountVM.Address;
                deliveryMan.BirthDateDelivery = accountVM.BirthDate;
                deliveryMan.EmailDelivery = accountVM.Email;
                deliveryMan.FirstNameDelivery = accountVM.FirstName;
                deliveryMan.NameDelivery = accountVM.Name;
                deliveryMan.PhoneNumberDelivery = accountVM.PhoneNumber;
                deliveryMan.PasswordDelivery = accountVM.Password;
                deliveryMan.IsWorking = 0;
                deliveryMan.nbDeliveries = 0;
                deliveryMan.ID_Location = location.ID_location;
                deliveryMan.ID_workLocation = workLocation.ID_location;
                deliveryMan.ImageDelivery = "limagedudeliveryman";
                DeliveryManManager.AddDeliveryMan(deliveryMan);

                // Tout juste, donc retourne à l'index
                return View("Index");            
            }
                        
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPerson(AccountVM accountVM)
        {
            //voit si toutes les informations son bien mises
            if (ModelState.IsValid)
            {
                //verifie que la Location soit correcte
                var idLocation = LocationManager.GetLocationNPACity(accountVM.NPA, accountVM.City);
                if (idLocation == 0)
                {
                    ModelState.AddModelError("NPA", "le NPA ou la ville est incorrect");
                    return View();
                }
                var location = LocationManager.GetLocationID(idLocation);
                                
                // Ajout données deliveryMan
                Person person = new Person();
                person.Address = accountVM.Address;
                person.BirthDate = accountVM.BirthDate;
                person.MailAddress = accountVM.Email;
                person.FirstName = accountVM.FirstName;
                person.Name = accountVM.Name;
                person.PhoneNumber = accountVM.PhoneNumber;
                person.PasswordLogin = accountVM.Password;
                person.isRestaurant = 0;
                person.ID_location = location.ID_location;
                person.PersonImage = "limagedelapersonne";
                PersonManager.AddPerson(person);

                // Tout juste, donc retourne à l'index
                return View("Index");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Account(AccountVM accountVM)
        {
            
            //voit si toutes les informations son bien mises
            if (ModelState.IsValid)
            {
                //verifie que la Location soit correcte
                var idLocation = LocationManager.GetLocationNPACity(accountVM.NPA, accountVM.City);
                if (idLocation == 0)
                {
                    ModelState.AddModelError("NPA", "le NPA ou la ville est incorrect");
                    return View();
                }
                var location = LocationManager.GetLocationID(idLocation);
                
                // modification des informations du compte
                int accountID = (int)HttpContext.Session.GetInt32("IdPerson");
                Person person = new Person();
                person.ID_person = accountID;
                person.Address = accountVM.Address;
                person.BirthDate = accountVM.BirthDate;
                person.MailAddress = accountVM.Email;
                person.FirstName = accountVM.FirstName;
                person.Name = accountVM.Name;
                person.PhoneNumber = accountVM.PhoneNumber;
                person.PasswordLogin = accountVM.Password;
                person.isRestaurant = 0;
                person.ID_location = location.ID_location;
                person.PersonImage = "limagedelapersonne";
                PersonManager.ModifyAllPerson(person);


                return View("Account");
            }

            return View("Account");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AccountDeliveryMan(AccountVM accountVM)
        {

            //voit si toutes les informations son bien mises
            if (ModelState.IsValid)
            {
                //verifie que la Location soit correcte
                var idLocation = LocationManager.GetLocationNPACity(accountVM.NPA, accountVM.City);
                if (idLocation == 0)
                {
                    ModelState.AddModelError("NPA", "le NPA ou la ville est incorrect");
                    return View();
                }
                var location = LocationManager.GetLocationID(idLocation);

                //verifie que la Location du lieu de travâil soit correcte
                var idWorkLocation = LocationManager.GetLocationNPACity(accountVM.WorkNPA, accountVM.WorkCity);
                if (idWorkLocation == 0)
                {
                    ModelState.AddModelError("NPA", "le NPA ou la ville du lieu de travail est incorrect");
                    return View();
                }
                var workLocation = LocationManager.GetLocationID(idWorkLocation);

                // modification des informations du compte
                // récupérer les informations qui ne changeront pas              
                int accountID = (int)HttpContext.Session.GetInt32("IdDeliveryMan");
                DeliveryMan noChangeDeliveryMan = DeliveryManManager.GetDeliveryManID(accountID);

                // récupérer et ajouter les modifications pouvant être changées
                DeliveryMan deliveryMan = new DeliveryMan();
                deliveryMan.AddressDelivery = accountVM.Address;
                deliveryMan.BirthDateDelivery = accountVM.BirthDate;
                deliveryMan.EmailDelivery = accountVM.Email;
                deliveryMan.FirstNameDelivery = accountVM.FirstName;
                deliveryMan.NameDelivery = accountVM.Name;
                deliveryMan.PhoneNumberDelivery = accountVM.PhoneNumber;
                deliveryMan.PasswordDelivery = accountVM.Password;
                deliveryMan.ID_Location = location.ID_location;
                deliveryMan.ImageDelivery = "limagedelapersonne";

                // ajouter les modifications ne pouvant pas être changées
                deliveryMan.ID_workLocation = workLocation.ID_location;
                deliveryMan.Id_Delivery = accountID;
                deliveryMan.IsWorking = noChangeDeliveryMan.IsWorking;
                deliveryMan.nbDeliveries = noChangeDeliveryMan.nbDeliveries;


                DeliveryManManager.ModifyAllDeliveryMan(deliveryMan);
                return View("AccountDeliveryMan");
            }

            return View("AccountDeliveryMan");
        }

        public IActionResult Logout()
        {
            //supprime l'id de la personne et du livreur
            HttpContext.Session.Remove("IdDeliveryMan");
            HttpContext.Session.Remove("IdPerson");
            return View("Index");
        }

        
    }
}