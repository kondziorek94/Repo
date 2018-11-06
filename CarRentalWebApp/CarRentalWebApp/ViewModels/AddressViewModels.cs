using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentalWebApp.Models
{
    public class AddressDetailsViewModel
    {
        public IEnumerable<Survey> Surveys { get; set; }
        public Address Address { get; set; }
    }
}