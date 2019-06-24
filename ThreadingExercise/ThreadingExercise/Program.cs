using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadingExercise
{
    public class Program
    {
        private BlockingCollection<int> queue = new BlockingCollection<int>();
        public void Producer()
        {
            int integer = 0;
            for(int i = 0; i < 10; i++)
            {
                
                queue.Add(integer);
                integer++;
            }
            queue.CompleteAdding();
        }
        public void Consumer()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(""))
            {

            }
        }
        public static void Main(string[] args)
        {
        }
    }
}
