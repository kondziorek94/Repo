using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
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
            survey.Questions.SelectMany(q => q.Answers).Intersect(address.Answers, AnswerComparer.Instance).ToList().ForEach(answer => answer.IsChecked = true);

            var surveyFillViewModel = new SurveyFillViewModel { Survey = survey, Address = address };

            return View(surveyFillViewModel);
        }

        public String CheckAnswer(String addressId, String answerId)
        {
            if (addressId == null || answerId == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            Guid addressIdGuid, newAnswerIdGuid;
            try
            {
                addressIdGuid = Guid.Parse(addressId);
                newAnswerIdGuid = Guid.Parse(answerId);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(addressIdGuid);
            Answer newAnswer = db.Answers.Find(newAnswerIdGuid);
            if (address == null || newAnswer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            var result = "false";

            Answer previousAnswer = address.Answers.Find(a => a.Question.Id == newAnswer.Question.Id);
            if (previousAnswer != null && previousAnswer.Id == newAnswer.Id)
            {
                result = "true";
            }
            return result;

        }

        public void SaveAnswer(String addressId, String answerId)
        {
            //parsuj w tryu, jezeli bedzie wyjatek to rzuc http bad request
            if (addressId == null || answerId == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            Guid addressIdGuid, answerIdGuid;
            try
            {
                addressIdGuid = Guid.Parse(addressId);
                answerIdGuid = Guid.Parse(answerId);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(addressIdGuid);
            Answer answer = db.Answers.Find(answerIdGuid);
            if (address == null || answer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            //Wybierz z posrod udzielonych opodwiedzi dla adresu taka ktora jest przyporzadkowana do tego samego pytania co answer(udzielna)
            Answer previousAnswer = address.Answers.Find(a => a.Question.Id == answer.Question.Id);


            //sprawdz czy odpowiedz na to pytanie byla juz udzielona dla tego adresu
            //Jezeli tak: to usun ta odpowiedz (mozna upsrawnic zeby usuwal tylko jezeli zostala dana inna odpowiedz niz poprzednio)
            //Jezeli nie: to nic
            //Przypisz nowa odpowiedz do danego adresu (no chyba ze nie trzeba bo nie usunales bo byla taka sama udzielona)
            if (previousAnswer != null)
            {
                address.Answers.RemoveAll(a => a.Id == previousAnswer.Id);
            }
            address.Answers.Add(answer);


            //pobierz ze wszystkich odpowiedzi przypisanych do tego adresu, odpowiedz o id identycznym z dana odpowiedzia z ankiety
            //Answer answer = address.Answers.Find(a=>a.Id==answerIdCopy);
            //answer = db.Answers.Find(answerId);
            db.SaveChanges();
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

//PRACA DOMOWA 
//spraw aby po zaladowaniu ankiety byly widoczne poprzednio udzielone odpowiedzi