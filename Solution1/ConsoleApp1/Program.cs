﻿using System;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{

    public enum CardType
    {
        Clubs, Diamonsds, Spades, Hearts
    }

    public class Card
    {
        public CardType CardType { get; set; }

        public Card(CardType cardType)
        {
            CardType = cardType;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Card card = new Card(CardType.Spades);


            string s = "12";
            string pattern = @"^-?(\d+)*(?:\.\d+)$";


            //string pattern = @"^-?(\d+)*(?:\.\d+)(\s+)(\+|\-|\*|/|\%)(\s+)(\d+)*(?:\.\d+)$";
            //string pattern = @"^(\d+)(\s+)(\+|\-|\*|/|\%)(\s+)(\d+)$";

            // "^(\d+)(\s)(\+|-|%|\\|*)(\s)(\d+)$"

            if (Regex.IsMatch(s, pattern))
            {
                Console.WriteLine("MATCH");
            }


            MatchCollection matches = Regex.Matches(s, pattern);
            if (matches.Count > 0)
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
