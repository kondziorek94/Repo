using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentalWebApp.Models
{
    public class Answer
    {
        public Guid Id { get; set; }
        public String Text { get; set; }
        public virtual Question Question { get; set; }
        public virtual List<Address> Address { get; set; }

    }
}