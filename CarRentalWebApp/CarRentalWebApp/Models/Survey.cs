using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentalWebApp.Models
{
    public class Survey
    {
        public Guid Id { get; set; }
        public String Title { get; set; }
        public virtual List<Question> Questions { get; set; }
      
    }
}
///NA NASTEPNYCH ZAJECIACH PRZYPOMNIJ LAzy LOADING