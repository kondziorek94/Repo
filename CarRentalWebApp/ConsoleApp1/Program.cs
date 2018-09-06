using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            

            string s = "12";
            string pattern =  @"^-?(\d+)*(?:\.\d+)$";


            //string pattern = @"^-?(\d+)*(?:\.\d+)(\s+)(\+|\-|\*|/|\%)(\s+)(\d+)*(?:\.\d+)$";
            //string pattern = @"^(\d+)(\s+)(\+|\-|\*|/|\%)(\s+)(\d+)$";

            // "^(\d+)(\s)(\+|-|%|\\|*)(\s)(\d+)$"

            if (Regex.IsMatch(s, pattern))
            {
                Console.WriteLine("MATCH");
            }


            MatchCollection matches = Regex.Matches(s, pattern);
            if(matches.Count > 0)
            {
                Match match = matches[0];
                Console.WriteLine(value: match.Groups[0]);
                Console.WriteLine(match.Groups[1]);
                Console.WriteLine(match.Groups[2]);
                Console.WriteLine(match.Groups[3]);
                Console.WriteLine(match.Groups[4]);
                Console.WriteLine(match.Groups[5]);
            }
            

            Console.ReadKey();
        }
    }
}
