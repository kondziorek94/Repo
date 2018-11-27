using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CarRentalWebApp.Models;
namespace CarRentalWebApp.Controllers
{
    public class SurveyController : Controller
    {
        private CarRentalDbContext db = new CarRentalDbContext();
        // GET: Survey
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Fill(Guid id, Guid addressId)
        {
            if (id == null || addressId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            Address address = db.Addresses.Find(addressId);
            if (survey == null || address == null)
            {
                return HttpNotFound();
            }
            var surveyFillViewModel = new SurveyFillViewModel { Survey = survey,Address=address };

            return View(surveyFillViewModel);
        }

    }
}