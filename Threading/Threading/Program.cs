using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Threading
{
    public class Program
    {
        private static volatile bool work = true;

        public static void M1()
        {
            while (true)
            {
                Console.WriteLine("M1");
                System.Threading.Thread.Sleep(2000);
            }
        }

        public static void M2()
        {
            while (work)
            {
                Console.WriteLine("M2");
                System.Threading.Thread.Sleep(2000);
            }
        }

        public static void Main(string[] args)
        {
            Thread t1 = new Thread(M1);
            Thread t2 = new Thread(M2);
            t1.Start();
            t2.Start();
            BlockingCollection<string> queue = new BlockingCollection<string>(1);
            queue.Add("tekst");

            //Add dziala w taki sposob ze jezeli jest wolne miejsce w kolekcji to wstawi do niej element, jezeli nie to czeka az zwolni sie miejsce
            Console.WriteLine(queue.Take());
            //pobiera i usuwa element z kolekcji badz czeka jezeli kolekcja jest pusta, pobierze element gdy co zostanie do niej dodane
            queue.CompleteAdding();
            Console.WriteLine(queue.IsCompleted && queue.Count == 0);
            Console.ReadKey();
            work = false;
        }
    }
}