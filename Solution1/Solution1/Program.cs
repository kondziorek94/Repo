using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Program
    {

        public static int max(int[] t)
        {
            int max = int.MinValue;
            foreach (int el in t)
            {
                if (max < el)
                {
                    max = el;
                }
            }
            return max;
        }


        public static int m(int x)
        {
            x++;
            return x;
        }
        public static int m(ref int x)
        {
            x++;
            return x;
        }
        //gdy uzywasz ref zmienna przekazywana do metody musi byc zainicjalizowana, gdy uzywasz out nie musi, ale za to mnusi byc zainicjalizowana wewnatrz metody
        public static int me(out int x)
        {
            x = 0;
            x++;
            return x;
        }
        static void Main(string[] args)
        {
            int x = 10;
            int[] t = new int[10];
            for (int i = 0; i < t.Length; i++)
            {//cw+2xTab ->Console.WriteLine()
                Console.WriteLine(t[i]);
            }

            int? nullableInt = null;
            var s = "fsafsafsa";
            var s1 =
                @"Ala ma kota 
                 costam ";
            Console.WriteLine(s1);
            int val = 10;
            m(val);//przekazuje wartosc zmiennej czyli przez wartosc
            Console.WriteLine(val);
            m(ref val);//przekazuje oryginal zmiennej czyli przez referencje
            Console.WriteLine(val);
            me(out val);//przekazuje oryginal zmiennej czyli przez referencje ale ta mienna i tak musi byc wsrodku czyms zainicjalzowana
            Console.WriteLine(val);
            Console.ReadKey();
        }
    }
}
//ctrl + l usuniecie linijki kodu
//ctrl + k,d autoformatowanie
//ctrl + k ,c komentowanie kodu
//ctrl + k,u odkowmentowywanie kodu
//f5 start
