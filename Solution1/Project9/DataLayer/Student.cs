﻿using System;
using System.Collections.Generic;

namespace Project9.DataLayer
{
    class Student : ObjectPlus
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Statistics> Statistics { get; private set; } = new List<Statistics>();

        public Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void AddStatistic(Statistics statistics)
        {
            if (!Statistics.Contains(statistics))
            {
                Statistics.Add(statistics);
                statistics.SetStudent(this);
            }
        }

        public override string ToString()
        {

            String s = "\n" + FirstName + " " + LastName + "\n";
            s += string.Join("\n", Statistics);

            return s;
        }
    }
}