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
            var surveyFillViewModel = new SurveyFillViewModel { Survey = survey, Address = address };

            return View(surveyFillViewModel);
        }
        [HttpPost]
        public void SaveAnswer(String addressId, String answerId)
        {
            Guid addressIdCopy = Guid.Parse(addressId);
            Guid answerIdCopy = Guid.Parse(answerId);
            Address address = db.Addresses.Find(addressIdCopy);
            Answer answer = address.Answers.Find(a=>a.Id==answerIdCopy);
            answer = db.Answers.Find(answerId);
            db.SaveChanges();
            return ;
        }

    }
}


//strona backendu
//1 zmienic nazwe metody i wprowadzic dwa parametry addressId oraz answerId
//done
//2 pobrac odpowiednie obiekty z bazy danych i zapisac/aktualizowac udzielona odpowiedz dla danego addresu
//done

//strona frontendu
//1. zaktualizowac url aby przekazywac odpowiednie argumenty
//2. usunac alerty

//button gradient