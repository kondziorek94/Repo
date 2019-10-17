using System;

namespace Project5
{
    public delegate int Operation(int a, int b);

    class Program
    {

        public static int Addition(int a, int b)
        {
            return a + b;
        }

        public static void PerformOperation(Operation o, int a, int b)
        {
            Console.WriteLine(o(a, b));
        }

        static void Main(string[] args)
        {
            PerformOperation(Addition, 10, 5);
            PerformOperation((int d, int e) =>
            {
                Console.WriteLine("cokolwiek chce");
                return d * e;
            }, 10, 5);
            PerformOperation((d, e) =>
            {
                Console.WriteLine("cokolwiek chce");
                return d * e;
            }, 10, 5);
            int x = 6, y = 8;
            Console.WriteLine(x > y ? "x wieksze od y" : "x nie jest wieksze od y");//ternary operator
            PerformOperation((d, e) => d * e, 10, 5);
            Console.ReadKey();
        }
    }
}