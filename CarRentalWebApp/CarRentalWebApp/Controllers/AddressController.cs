using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarRentalWebApp.Models;
//DOPROWADZENIE PROJEKTU DO STANU Z OSTATNICH ZAJEC
//Wyswietla sie numer atkualnej stronya w polu tekstowym
//Mozna filtrowac wyniki i sa one stronicowane, czyli wyszukujesz a potem masz np. 2 strny z wynikiami
//Sortowanie dziala ze stronicowaniem

//Praca domowa
//Stworz dropdown w ktorym mozesz wybrac wielkosc strony :2,5,8,10 rekordow




//Zadanie
//Stwórz nowy kontroler, ten kontroler ma miec funkcjonalnosc kalkulatora, na poczatek ma tylko dodawac
//jezeli podasz mu argumenty a=4 i b=7 to on zwroci widok na ktorym bedzie mozna zobaczyc napis 4 + 7 = 11
namespace CarRentalWebApp.Controllers
{
    //do kalkulatora dodaj mozliwosc wpisywania zmiannej x, dzieki ktorej bedziesz mogl pisac wzory funkcji np.
    //x * x + 4
    //5*x  + 5
    //dodaj przyicsk PLOT ktory wyrysuje funckje bez przeladowywania strony
    public class AddressController : Controller
    {
        public const int PAGE_SIZE = 5;
        private CarRentalDbContext db = new CarRentalDbContext();
            //cis
        // GET: Address
        public ActionResult Index(string searchPhrase, string order, int? pageNumber)
        {
            List<Address> list;
            if (!String.IsNullOrWhiteSpace(searchPhrase))
            {
                list = db.Addresses.Where(a => a.CityName.Contains(searchPhrase) ||
                                               a.StreetName.Contains(searchPhrase) ||
                                               a.ZipCode.Contains(searchPhrase) ||
                                               a.PhoneNumber.Contains(searchPhrase)).ToList();
            }
            else
            {
                list = db.Addresses.ToList();
            }
            //potem osobno posortowac po nazwie miasta
            if (!String.IsNullOrWhiteSpace(order))
            {
                var splitOrder = order.Split('_');
                var propertyName = splitOrder[0];
                order = splitOrder[1];
                if (order.Equals("Asc"))
                {
                    list = list.OrderBy(o => o.GetType().GetProperty(propertyName).GetValue(o, null)).ToList();
                }
                else if (order.Equals("Desc"))
                {
                    list = list.OrderByDescending(o => o.GetType().GetProperty(propertyName).GetValue(o, null)).ToList();
                }
            }
            int currentPage=(pageNumber.HasValue ? pageNumber.Value : 1);

            list = list.Skip((currentPage - 1) * PAGE_SIZE).Take(PAGE_SIZE).ToList();
            ViewBag.TotalPageNumber = GetNumberPages();
            //return widok
            return View(list);

        }

        // GET: Address/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // GET: Address/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Address/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CityName,StreetName,ZipCode,PhoneNumber")] Address address)
        {
            if (ModelState.IsValid)
            {
                address.Id = Guid.NewGuid();
                db.Addresses.Add(address);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(address);
        }

        // GET: Address/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }


        // POST: Address/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CityName,StreetName,ZipCode,PhoneNumber")] Address address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(address);
        }
        [HttpPost]
        public String GetNumberPages()
        {
            int recordNumber = db.Addresses.Count();
            return recordNumber % PAGE_SIZE == 0 ?
                 (recordNumber / PAGE_SIZE).ToString() :
                 (recordNumber / PAGE_SIZE + 1).ToString();
        }

        // GET: Address/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: Address/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Address address = db.Addresses.Find(id);
            db.Addresses.Remove(address);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
