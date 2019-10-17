using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;

namespace ProducerConsumer
{
    class Program
    {
        private static BlockingCollection<int> queue = new BlockingCollection<int>();
        private static volatile bool work = true;

        public static void Producer()
        {
            Random random = new Random();
            int integer = 0;
            while (work)
            {
                var timeMS = random.Next(1000, 3000);
                Thread.Sleep(timeMS);
                Console.WriteLine("dodaje do kolejki");
                queue.Add(integer);
                Console.WriteLine("po dodaniu do kolejki");
                integer++;
            }
            queue.CompleteAdding();
        }

        public static void Consumer()
        {
            while (queue.Count > 0 || !queue.IsCompleted)
            {
                Console.WriteLine("pobiera z kolejki");
                File.AppendAllText("out.txt", queue.Take().ToString());
                Console.WriteLine("po pobraniu z kolejki");
            }
        }

        public static void Main(string[] args)
        {
            Thread t1 = new Thread(Producer);
            Thread t2 = new Thread(Consumer);
            t1.Start();
            t2.Start();
            Console.ReadKey();
            work = false;
        }
    }
}