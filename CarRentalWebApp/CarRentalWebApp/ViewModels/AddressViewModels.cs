using System.Collections.Generic;
namespace CarRentalWebApp.Models
{
    public class AddressDetailsViewModel
    {
        public IEnumerable<Survey> Surveys { get; set; }
        public Address Address { get; set; }
    }
}