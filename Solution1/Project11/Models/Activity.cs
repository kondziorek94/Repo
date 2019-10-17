using System;
using System.Collections.Generic;

namespace Project11.Models
{
    public class Activity
    {
        public Guid ActivityId { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public virtual List<Student> Students { get; set; }
    }
}