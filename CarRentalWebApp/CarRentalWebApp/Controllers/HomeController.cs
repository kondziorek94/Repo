using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarRentalWebApp.Models;

namespace CarRentalWebApp.Controllers
{
    public class HomeController : Controller
    {

        public HomeController() : base()
        {
        }

        //action
        public ActionResult Index()
        {
            return View();
        }
        //adresAplikacji/NazwaKontrolera/NazwaMetody
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page!";
            dynamic o = new System.Dynamic.ExpandoObject();
            o.Roman = "Cos";
            ViewBag.o = o;


            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.Val = 10;
            ViewBag.Address = new Address { CityName = "Redmond, WA", StreetName = "One Microsoft Way", PhoneNumber = "425.555.0100", ZipCode = "98052-6399" };
            ViewData["vala"] = "VAL from ViewData";
            // var a1 = new Address { CityName = "Warszawa", StreetName = "Kolejowa", PhoneNumber = "22 755-32-02", ZipCode = "00-001" };
            //var a1 = odczytaj obiekt z bazy;
            List<Address> a1 = null;

            //1. tworzy sie context w klazuli using 
            //2. odcytaj obiekt uzywajac wlasciwego DbSeta
            using (CarRentalDbContext context = new CarRentalDbContext())
            {
                a1 = context.Addresses.ToList();
            }
                return View(a1);
        }
    }
}