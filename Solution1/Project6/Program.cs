using Project4;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Project6
{
    class Program
    {
        //napisz metoda ktora wypisze wszystkie liczby z danego pliku(dajesz sciezke jako string) podzielne przez 5
        static void dividableByFive(string path)
        {
            IEnumerable<int> list = new List<string>(File.ReadAllLines(path)).Select(number => Convert.ToInt32(number)).Where(number => number % 5 == 0);
            Console.WriteLine(string.Join(",", list));
        }

        //napisz metoda ktora wypisze wszystkie liczby z pliku numbers1.txt bez powtorzen(czyli jezeli dwukrotnie lub wiecej wystapi jakas wartosc w pliku to i tak wypiszesz ja raz)
        static void noRepetition()
        {
            IEnumerable<String> list = new List<string>(File.ReadAllLines("numbers1.txt")).Distinct();
            Console.WriteLine(string.Join(",", list));
        }

        //to samo ale tym razem wartosci beda posortowane(order by)
        static void noRepetitionSorted()
        {
            IEnumerable<int> list = new List<string>(File.ReadAllLines("numbers1.txt")).Distinct().Select(number => Convert.ToInt32(number)).OrderBy(e => e);
            Console.WriteLine(string.Join(",", list));
        }

        //wypisze dlugosci kolejnych liczb zawartych w pliku
        static void numberLength(string path)
        {
            IEnumerable<int> list = new List<int>(File.ReadAllLines(path).Select(number=>number.Length));
            Console.WriteLine(string.Join(" ", list));
        }

        //napisz metoda ktora wypisze wszystkie liczby z pliku numbers1.txt ktore sa tez w pliku numbers2.txt
        static void samNumbers()
        {
            IEnumerable<int> list1 = new List<int>(File.ReadAllLines("numbers1.txt").Select(number=>Convert.ToInt32(number)));
            IEnumerable<int> list2 = new List<int>(File.ReadAllLines("numbers2.txt").Select(number=>Convert.ToInt32(number)));
            IEnumerable<int> result = list1.Intersect(list2);
            Console.WriteLine(string.Join(" ", result));
        }

        //napisz metode ktora wypisze wszystkie liczby z pliku numbers1.txt ktorych nie ma w pliku numbers2.txt
        static void differentNumbers()
        {
            IEnumerable<int> list1 = new List<int>(File.ReadAllLines("numbers1.txt").Select(number => Convert.ToInt32(number)));
            IEnumerable<int> list2 = new List<int>(File.ReadAllLines("numbers2.txt").Select(number => Convert.ToInt32(number)));
            IEnumerable<int> result = list1.Except(list2);
            Console.WriteLine(string.Join(" ", result));
        }

        static void Main(string[] args)
        {
            Random r = new Random();
            using (StreamWriter sw1 = new StreamWriter("numbers1.txt"), sw2 = new StreamWriter("numbers2.txt"))
            {
                for (int i = 0; i < 100; i++)
                {
                    sw1.WriteLine(r.Next(1000));
                    sw2.WriteLine(r.Next(1000));
                }
            }
            dividableByFive("numbers1.txt");
            noRepetition();

            //napisz wyrazenie ktore wypisze na konsole srednia wieku wszystkich osob z listy
            List<Person> listOfPeople = new List<Person>() {
                    new Person("Andrzej", 43),
                    new Person("Agnieszka",  26),
                    new Person("Janusz",41),
                    new Person("Izabela", 52),
                    new Person("Izabela", 14),
                    new Person("Izabela", 20)
                };

            //wypisz wszystkie osoby ktore sa mlodsze niz 50 lat
            Console.WriteLine(string.Join(",", listOfPeople.Where(person => person.Age < 50)));
            Console.WriteLine(string.Join(",", listOfPeople.Select(person => person.Name.Length)));
            noRepetitionSorted();
            Console.WriteLine(string.Join(",", listOfPeople.OrderBy(p => p.Name).ThenBy(p => p.Age)));
            numberLength("numbers1.txt");
            samNumbers();
            differentNumbers();
            Console.ReadKey();
        }
    }
}