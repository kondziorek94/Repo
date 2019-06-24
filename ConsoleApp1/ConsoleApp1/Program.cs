using System;
using System.Drawing;

namespace ConsoleApp1
{
    
    class Program
    {
        public class DPI
        {

            public static float[] GetDpi()
            {
                using (Graphics graphics = graphics.FromHwnd(IntPtr.Zero))
                {
                    float dpiX = graphics.DpiX;
                    float dpiY = graphics.DpiY;
                    float[] result = new float[] { dpiX = dpiX, dpiY = dpiY };
                    return result;
                }
            }


        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
