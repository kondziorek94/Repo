using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeworkSelectMany
{
    public class Person
    {
        public List<int> Numbers { get; set; }
        public Person() { }
    }
    class Program
    {

        public static void Main(string[] args)
        {
            Person person1 = new Person
            {
                Numbers = new List<int> { 2, 3, 7, 4 }
            };
            Person person2 = new Person
            {
                Numbers = new List<int> { 1, 5, 6, 8, 4 }
            };
            List<Person> people = new List<Person> { person1, person2 };
            //List<int> mergedList=people.SelectMany(o => o.Numbers);
            Console.WriteLine("First list count: "+person1.Numbers.Count);
            Console.WriteLine(String.Join(", ",person1.Numbers));
            Console.WriteLine("Second list count: " + person2.Numbers.Count);
            Console.WriteLine(String.Join(", ", person2.Numbers));
            Console.WriteLine("Joined list count:" + (people.SelectMany(o => o.Numbers)).ToList().Count);
            Console.WriteLine(String.Join(", ", (people.SelectMany(o => o.Numbers)).ToList()));
            Console.ReadKey();
        }


    }
}


