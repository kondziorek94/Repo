using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CarRentalWebApp.Models;
//adresAplikacji/NazwaKontrolera/NazwaMetody
namespace CarRentalWebApp.Controllers
{
    public class HomeController : Controller
    {
        public HomeController() : base()
        {
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAbout()
        {
            ViewBag.Message = "Your application description page!";
            dynamic o = new System.Dynamic.ExpandoObject();
            o.Roman = "Cos";
            ViewBag.o = o;
            return View();
        }

        public ActionResult GetContact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.Val = 10;
            ViewBag.Address = new Address { CityName = "Redmond, WA", StreetName = "One Microsoft Way", PhoneNumber = "425.555.0100", ZipCode = "98052-6399" };
            ViewData["vala"] = "VAL from ViewData";
            List<Address> a1 = null;
            using (CarRentalDbContext context = new CarRentalDbContext())
            {
                a1 = context.Addresses.ToList();
            }
            return View(a1);
        }
    }
}