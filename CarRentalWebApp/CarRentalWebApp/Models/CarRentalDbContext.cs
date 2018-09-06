using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace CarRentalWebApp.Models
{
    public class CarRentalDbContext: DbContext
    {
        public DbSet<Address> Addresses { get; set; }

        public CarRentalDbContext() : base("MainDb") { }
    }
}

//1. enable-migrations -v
//2. update-database -v