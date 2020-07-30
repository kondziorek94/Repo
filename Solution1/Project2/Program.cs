using System;

namespace Project2
{
    public class Employee
    {
        private string name;
        private double hourlyRate;
        public int HoursPerMonth { get; set; }//to jest wlasciwosc automatyczna(auto property) z getterm i setterem, pod spodem powstaje pole o nazwie ktorej nei znasz ktore przetrzymuje wartosci ktore przypisujesz do tej wlasciowsci
        //property-wlasciwosc pozwala na deklarowanie accesorow czyli getter i setterow i uzywanie ich niewprost
        public double HourlyRate
        {
            get
            {
                Console.WriteLine("GETTER SIE WYWOLAL");
                return hourlyRate;
            }
            set//value w setterze to wartosc wyrazenia po stronie RHS
            {
                Console.WriteLine("SETTERSIE WYWOLAL");
                hourlyRate = value;
            }
        }

        public Employee(string name, double hourlyRate, int hoursPerMonth)
        {
            this.name = name;
            HourlyRate = hourlyRate;
            HoursPerMonth = hoursPerMonth;
        }

        public Employee() : this("Bozydar", 10, 10)
        {
        }

        public void IntroduceYouslelf()
        {
            Console.WriteLine("Hi");
        }
    }

    public class Product
    {
        public double PriceWoTax { get; set; }
        public const double TAX = 0.22;//STALA STATYCZNA, wszystkie stale ktore sa polami sa automatycznie statyczne
        public double PriceWTax//atrybut pochodny/wyliczalny, nie przetrzymujesz jego wartosci ale wyliczasz go na podstawie innych atrybutow
        {
            get
            {
                return PriceWoTax * (1 + TAX);
            }
            set
            {
                PriceWoTax = value / (1 + TAX);
            }
        }

        public override string ToString()
        {
            return base.ToString() + "Price with tax: " + PriceWTax + " price without tax: " + PriceWoTax;
        }
    }

    public class A
    {
        public A() { }
    }

    public class B : A
    {
        public B() : base() { }
    }

    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public double PricePerDay { get; set; }

        public Car(string make, string model, double pricePerDay)
        {
            Make = make;
            Model = model;
            PricePerDay = pricePerDay;
        }
    }

    public class Rental
    {
        public Car RentedCar { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public double RentCost => (EndingDate - StartingDate).Days * RentedCar.PricePerDay;
        public override String ToString()
        {
            return String.Format("Cost of renting {0} {1} is {2} dolarow", RentedCar.Make, RentedCar.Model, RentCost);
       
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee e = new Employee("roman", 100, 160);
            e.HourlyRate = 10;
            Console.WriteLine(e.HourlyRate);
            e.IntroduceYouslelf();

            Product product = new Product { PriceWoTax = 5 };
            Console.WriteLine(product);
            product.PriceWTax = 10;
            Console.WriteLine(product);
            Car c = new Car("Audi", "A8", 250);
            Rental rental = new Rental { RentedCar =  c,StartingDate= new DateTime(2017,04,02),EndingDate=new DateTime(2017,04,10)};
            Console.WriteLine(rental.RentCost);
            Console.WriteLine(c.Model);
            Console.WriteLine(rental);
            Console.ReadKey();
        }
    }
}