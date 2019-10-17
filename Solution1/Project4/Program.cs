using System;
using System.Collections.Generic;

namespace Project4
{
    public class Person : IComparable<Person> 
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            int result = 1;
            result = prime * result + Age;
            result = prime * result + ((Name == null) ? 0 : Name.GetHashCode());
            return result;
        }

        public override Boolean Equals (Object obj)
        {
            if (this == obj)
                return true;
            if (obj == null)
                return false;
            if (GetType() != obj.GetType())
                return false;
            Person other = (Person)obj;
            if (Age != other.Age)
                return false;
            if (Name == null)
            {
                if (other.Name != null)
                    return false;
            }
            else if (!Name.Equals(other.Name))
                return false;
            return true;
        }

        public override string ToString()
        {
            return "the name is: " + Name + " and age is:" + Age;
        }

        //zwracana jest wartosc
        //dodatnia gdy this jest wieksze od other
        //ujemna gdy this jest mniejase od other
        //0 gdy sa takie same
        public int CompareTo(Person other)
        {
            return Age - other.Age;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            {
                IList<int> list = new List<int>() { 10, 5, 4, 2, 3, 5, 19, 6, 1, 2 };
                foreach (int x in list)
                {
                    Console.WriteLine(x);
                }
                Console.WriteLine(string.Join(", ", list));
                Console.WriteLine(list.Contains(10));
            }
            {
                List<Person> listOfPeople = new List<Person>() {
                    new Person("Andrzej", 43),
                    new Person("Agnieszka",  26),
                    new Person("Janusz",41),
                    new Person("Izabela", 52)
                };
                Console.WriteLine(string.Join(Environment.NewLine, listOfPeople));
                Console.WriteLine(listOfPeople.Contains(new Person("Janusz", 41)));
                Console.WriteLine("------------------------------");
                listOfPeople.Sort();
                Console.WriteLine(string.Join(Environment.NewLine, listOfPeople));
                Console.WriteLine("------------------------------");
                listOfPeople.Sort((p1, p2) => p1.Name.CompareTo(p2.Name));
                Console.WriteLine(string.Join(Environment.NewLine, listOfPeople));
                Operacja o = Math.Max;
                Console.WriteLine(o(10,5));
            }
            Console.ReadKey();
        }

        public static int Addition(int a, int b)
        {
            return a + b;
        }

        public static int Subtraction(int a, int b)
        {
            return a - b;
        }
    }
    delegate int Operacja(int a, int b);//delegat i on mowi ze wszystkie metody co przyjmuja dwa inty i zwracaja inta sa typu Operacja
}