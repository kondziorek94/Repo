﻿using System;
using System.Collections.Generic;
namespace CarRentalWebApp.Models
{
    public class Survey
    {
        public Guid Id { get; set; }
        public String Title { get; set; }
        public virtual List<Question> Questions { get; set; }
    }
}
