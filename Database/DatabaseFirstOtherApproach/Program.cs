using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseFirstOtherApproach.Designer;

namespace DatabaseFirstOtherApproach
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDataBaseEntities db = new AppDataBaseEntities();
            foreach(var item in db.Receipts)
            {
                Console.WriteLine(item.ServiceName);
            }
            Console.ReadKey();
            
        }
    }
}
