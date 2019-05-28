using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public virtual List<Receipt> Receipts { get; set; }
    }


    class A
    {
        public void M()
        {
            Console.WriteLine("M");
        }
        public virtual void F()
        {
            Console.WriteLine("F");
        }
    }

    class B : A
    {
        public new void M()
        {
            Console.WriteLine("new M");
        }
        public override void F()
        {
            Console.WriteLine("override F");
        }
    }
}
