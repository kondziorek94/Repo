using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace CarRentalWebApp.Models
{
    public enum ImportanceLevel
    {
        VIP, Critical, Regular
    }
    public class Address
    {
        public Guid Id { get; set; }
        public String CityName { get; set; }
        public String StreetName { get; set; }
        public String ZipCode { get; set; }
        [RegularExpression(@"^\d{3}-\d{3}-\d{3}$", ErrorMessage = "Ivalid Phone Number")]
        public String PhoneNumber { get; set; }
        public ImportanceLevel ImportanceLevel { get; set; }
    }
}