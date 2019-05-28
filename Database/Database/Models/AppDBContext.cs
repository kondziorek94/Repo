using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class AppDBContext : DbContext
    {
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }
        public AppDBContext() : base("AppDataBase")
        {
            Configuration.LazyLoadingEnabled = true;
        }

    }
}

//do klienta dodaj artrybut pochodny (poprzez wlasciwosc z getterem bez settera) ktora zwraca laczna kwote zakupow na podstawie paragonow, nazwij ja TotalSpending 
//do domu dodaj klase invoice dziedziacza po Receipt z polem NIP(lub po angielksu jak to tam jest)
//dodaj jakis invoice do bazy danych, masz zaimplementowac dziedziczenie poprzez TPT - Table Per Type https://www.entityframeworktutorial.net/code-first/inheritance-strategy-in-code-first.aspx
//na nastepnych zajeciach podejscie database first