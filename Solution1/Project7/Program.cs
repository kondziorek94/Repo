using System;
using System.Collections.Generic;
namespace Project7
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person { Name = "Bozydar", LastName = "Bystry", BirthDate = new DateTime(1956, 7, 12), Discount = 15 };
            Person p2 = new Person { Name = "Janusz", LastName = "Klin", BirthDate = new DateTime(1981, 4, 1), Discount = 20 };
            Rental r1 = new Rental { StartDate = new DateTime(2006, 7, 12), EndDate = new DateTime(2007, 7, 12) };
            Car c = new Car { Make = "Nissan", Model = "Maxima", VIN = "N982FJEKWJ3JA92HHCJ2", PricePerDay = 113.89 };
            Car c2 = new Car { Make = "Audi", Model = "A8", VIN = "VW2B85G4HSIHI34BNKJBFDE3", PricePerDay = 125.67 };
            p.AddRental(r1);
            c.AddCarToRental(r1);
            Console.WriteLine(string.Join(" ", c.CarRentals));
            r1.SetPerson(p2);
            r1.SetCar(c2);
            Console.WriteLine("Person " + r1.Person);
            Console.WriteLine(p2.Rentals.Count);
            Console.WriteLine("Car " + r1.Car);
            Console.WriteLine(p2.Rentals.Count);
            Console.ReadKey();
        }
    }
}

public class Person
{
    public string Name { get; set; }
    public String LastName { get; set; }
    public int Discount { get; set; }
    public DateTime BirthDate { get; set; }
    public List<Rental> Rentals { get; } = new List<Rental>();

    public void AddRental(Rental rental)
    {
        if (!Rentals.Contains(rental))
        {
            Rentals.Add(rental);
            rental.SetPerson(this);
        }
    }

    public void RemoveRental(Rental rental)
    {
        if (Rentals.Contains(rental))
        {
            Rentals.Remove(rental);
            rental.RemovePerson(this);
        }
    }

    public override string ToString()
    {
        return Name + " " + LastName + " " + Discount + " " + BirthDate;
    }
}

public class Rental
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int DiscountAtTheTimeOfRent { get; }
    public double TotalPrice
    {
        get
        {
            return (EndDate - StartDate).TotalDays * (100 - DiscountAtTheTimeOfRent) / 100 * Car.PricePerDay;
        }
    }
    public Person Person { get; private set; }
    public Car Car { get; set; }
    public Rental(Car car, Person person)
    {
        SetCar(car);
        SetPerson(person);
    }

    public Rental() { }

    public void SetPerson(Person person)
    {
        if (Person != null && Person != person)
        {
            RemovePerson(Person);
        }
        if (Person == null)
        {
            Person = person;
            Person.AddRental(this);
        }
    }

    public void RemovePerson(Person person)
    {
        if (Person != null)
        {
            Person temp = person;
            Person = null;
            temp.RemoveRental(this);
        }
    }

    public void SetCar(Car car)
    {
        if (Car != null && Car != car)
        {
            RemoveCar(Car);
        }
        if (Car == null)
        {
            Car = car;
            Car.AddCarToRental(this);
        }
    }

    public void RemoveCar(Car car)
    {
        if (Car != null)
        {
            Car temp = car;
            Car = null;
            temp.RemoveRental(this);
        }
    }
}

public class Car
{
    public String Make { get; set; }
    public String Model { get; set; }
    public double PricePerDay { get; set; }
    public String VIN { get; set; }
    public List<Rental> CarRentals { get; } = new List<Rental>();

    public void AddCarToRental(Rental rental)
    {
        if (!CarRentals.Contains(rental))
        {
            CarRentals.Add(rental);
            rental.SetCar(this);
        }
    }

    public void RemoveRental(Rental rental)
    {
        if (CarRentals.Contains(rental))
        {
            CarRentals.Remove(rental);
            rental.RemoveCar(this);

        }
    }

    public override string ToString()
    {
        return Make + " " + Model + " " + PricePerDay + " " + VIN;
    }
}