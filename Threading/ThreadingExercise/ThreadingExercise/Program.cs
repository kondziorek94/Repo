using System.Collections.Concurrent;

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