using System;
using System.Collections.Generic;
using System.Linq;

namespace Project9.DataLayer
{
    class Course : ObjectPlus
    {
        public string Name { get; set; }
        public List<Statistics> Statistics { get; private set; } = new List<Statistics>();

        public Course(string course)
        {
            this.Name = course;
        }

        public void AddStatistic(Statistics statistics)
        {
            if (!Statistics.Contains(statistics))
            {
                Statistics.Add(statistics);
                statistics.SetCourse(this);
            }
        }

        //returns Course for given name, creates new Course if it does not exist yet
        public static Course ForName(string name)
        {
            object o = Objects[typeof(Course)].Where(course => ((Course)course).Name == name).FirstOrDefault();
            return o == null ? new Course(name) : (Course)o;
        }

        public string toString()
        {
            return Name;
        }
    }
}