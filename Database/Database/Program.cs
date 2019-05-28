using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Models;

namespace Database
{
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            A c = new B();
            //gdy uzywasz new do napisanie metody decyduje typ referencji
            a.M();
            b.M();
            c.M();
            //gdy uzywasz override do nadpisania metody decyduje typ obiektu
            a.F();
            b.F();
            c.F();
            AppDBContext db = new AppDBContext();
            foreach (var item in db.Receipts)
            {
                var client = db.Clients.Find(item.Client.Id);
            }
            Console.ReadKey();
        }
    }
}
