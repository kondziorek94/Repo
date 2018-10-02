namespace CarRentalWebApp.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using CarRentalWebApp.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<CarRentalWebApp.Models.CarRentalDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
        protected override void Seed(CarRentalDbContext context)
        {
            Guid guid1 = new Guid("1F941B15-1BF9-4793-83F1-A5B8523AB118");
            Guid guid2 = new Guid("B0FAC3A3-7955-4A91-B0B3-A666021D4026");
            Guid guid3 = new Guid("0CF1D643-8EB0-4723-8CDA-1856074176F5");
            Guid guid4 = new Guid("9c5f0c7f-9b3a-4038-b33b-63e09c83b48c");
            Guid guid5 = new Guid("fafcf97f-53dc-4aaf-91e8-4bf3a4641b8d");
            Guid guid6 = new Guid("0aedb9d6-c952-44da-9fc1-b77f84b1f959");
            Guid guid7 = new Guid("66a27867-c1cf-4d79-b42e-60139c09fc80");
            Guid guid8 = new Guid("ff0cd57c-9272-4cf2-a042-b412a202f3ad");
            Guid guid9 = new Guid("87b7e23e-d598-404c-87f5-7b28a30d1132");
            Guid guid10 = new Guid("c8ad59d2-c458-4edb-b3b7-11f02228bc8a");
            Guid guid11 = new Guid("3711051f-368c-407f-b460-06d01bf7ca17");
            Guid guid12 = new Guid("df763abb-28ad-434f-ac9f-ca3ebb47ca7c");
            Guid guid13 = new Guid("fdf07d93-404c-43a8-a6e6-d504b6f344c1");
            Guid guid14 = new Guid("5549bd44-ebfa-42c7-8dbe-a993a3a13208");
            Guid guid15 = new Guid("f72670b8-cb91-4b66-ae96-607037a67cb9");
            Guid guid16 = new Guid("fc165813-df4e-4bf4-acc6-c81972a043f1");
            Guid guid17 = new Guid("ddd6e3d2-b983-4897-8b4c-3279a10ad1ff");
            Guid guid18 = new Guid("ee0c3f49-a648-4476-a465-a9fc2c73da6a");
            Guid guid19 = new Guid("e102cdc1-44c5-4e51-91af-ee908fd37eb9");
            Guid guid20 = new Guid("c880d2ca-2a61-4327-bd07-ecdae0da3465");

            Address address1 = new Address { Id = guid1, CityName = "New York, NY", StreetName = "Pembina Highway", PhoneNumber = "891-783-749", ZipCode = "551 783", ImportanceLevel=ImportanceLevel.Regular };
            Address address2 = new Address { Id = guid2, CityName = "Miami, FL", StreetName = "Donald Street", PhoneNumber = "573-624-942", ZipCode = "738 920", ImportanceLevel = ImportanceLevel.Critical};
            Address address3 = new Address { Id = guid3, CityName = "Los Angeles, CA", StreetName = "Regent Avenue", PhoneNumber = "745-361-295", ZipCode = "930 829", ImportanceLevel = ImportanceLevel.VIP };
            Address address4 = new Address { Id = guid4, CityName = "Chicago, IL", StreetName = "Fermor Avenue", PhoneNumber = "413-758-382", ZipCode = "592 739", ImportanceLevel = ImportanceLevel.Regular };
            Address address5 = new Address { Id = guid5, CityName = "Bufflo, NY", StreetName = "Main Street", PhoneNumber = "554-954-785", ZipCode = "105 674", ImportanceLevel = ImportanceLevel.Critical };
            Address address6 = new Address { Id = guid6, CityName = "Orlando, FL", StreetName = "Portage Avenue", PhoneNumber = "843-578-291", ZipCode = "246 964", ImportanceLevel = ImportanceLevel.VIP };
            Address address7 = new Address { Id = guid7, CityName = "Atlanta, GA", StreetName = "Osborne Street", PhoneNumber = "483-195-643", ZipCode = "575 103", ImportanceLevel = ImportanceLevel.Regular };
            Address address8 = new Address { Id = guid8, CityName = "Nashville, TN", StreetName = "5th Street", PhoneNumber = "612-019-169", ZipCode = "309 142", ImportanceLevel = ImportanceLevel.Critical };
            Address address9 = new Address { Id = guid9, CityName = "Indianapolis, IN", StreetName = "University Crescent", PhoneNumber = "213-305-756", ZipCode = "745 102", ImportanceLevel = ImportanceLevel.VIP };
            Address address10 = new Address { Id = guid10, CityName = "Kansas, MO", StreetName = "Ulanowska", PhoneNumber = "314-483-795", ZipCode = "901 384", ImportanceLevel = ImportanceLevel.Regular };
            Address address11 = new Address { Id = guid11, CityName = "Warszawa", StreetName = "Gleboka", PhoneNumber = "501-518-811", ZipCode = "21943", ImportanceLevel = ImportanceLevel.Critical };
            Address address12 = new Address { Id = guid12, CityName = "Krakow", StreetName = "Solidarnosci", PhoneNumber = "509-421-255", ZipCode = "46382", ImportanceLevel = ImportanceLevel.VIP };
            Address address13 = new Address { Id = guid13, CityName = "Lublin", StreetName = "Krasnicka", PhoneNumber = "302-281-573", ZipCode = "52845", ImportanceLevel = ImportanceLevel.Regular };
            Address address14 = new Address { Id = guid14, CityName = "Rzeszow", StreetName = "Zemborzycka", PhoneNumber = "728-472-674", ZipCode = "68291", ImportanceLevel = ImportanceLevel.Critical };
            Address address15 = new Address { Id = guid15, CityName = "Bydgoszcz", StreetName = "Pawia", PhoneNumber = "693-472-193", ZipCode = "57282", ImportanceLevel = ImportanceLevel.VIP };
            Address address16 = new Address { Id = guid16, CityName = "Bialystok", StreetName = "Odrodzenia", PhoneNumber = "583-839-100", ZipCode = "10384", ImportanceLevel = ImportanceLevel.Regular };
            Address address17 = new Address { Id = guid17, CityName = "Torun", StreetName = "Niepodleglosci", PhoneNumber = "500-638-683", ZipCode = "81924", ImportanceLevel = ImportanceLevel.Critical };
            Address address18 = new Address { Id = guid18, CityName = "Szczecin", StreetName = "Paderewskiego", PhoneNumber = "120-499-281", ZipCode = "91024", ImportanceLevel = ImportanceLevel.VIP};
            Address address19 = new Address { Id = guid19, CityName = "Katowice", StreetName = "Hutnicza", PhoneNumber = "601-272-572", ZipCode = "42834", ImportanceLevel = ImportanceLevel.Regular };
            Address address20 = new Address { Id = guid20, CityName = "Wroclaw", StreetName = "Jana Pawla II", PhoneNumber = "609-478-172", ZipCode = "72924", ImportanceLevel = ImportanceLevel.Critical };
            context.Addresses.AddOrUpdate(a => a.Id, new Address[]{
                address1,
                address2,
                address3,
                address4,
                address5,
                address6,
                address7,
                address8,
                address9,
                address10,
                address11,
                address12,
                address13,
                address14,
                address15,
                address16,
                address17,
                address18,
                address19,
                address20
            });
            context.SaveChanges();

            using (var applicationContext = new ApplicationDbContext())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(applicationContext));


                if (!roleManager.RoleExists("Administrator"))
                {
                    var role = new IdentityRole();
                    role.Name = "Administrator";
                    roleManager.Create(role);
                }
                if (!roleManager.RoleExists("RegularUser"))
                {
                    var role = new IdentityRole();
                    role.Name = "RegularUser";
                    roleManager.Create(role);
                }

                var store = new UserStore<ApplicationUser>(applicationContext);
                var manager = new ApplicationUserManager(store);
                var user1Email = "a@a.pl";
                if (manager.FindByEmail(user1Email) == null)
                {
                    var user = new ApplicationUser() { Email = user1Email, UserName = user1Email };
                    manager.Create(user, "Password2@");
                    manager.AddToRole(user.Id, "Administrator");
                }

                var user2Email = "b@b.pl";
                if (manager.FindByEmail(user2Email) == null)
                {
                    var user2 = new ApplicationUser() { Email = user2Email, UserName = user2Email };
                    manager.Create(user2, "Password3#");
                    manager.AddToRole(user2.Id, "RegularUser");
                }

                //praca domowa (opcjonalna, jak nie zrobisz to sie nic nie stanie, masz sie zajac rysowaniem funkcji)
                //2. zadbaj o to zeby zwykly uzytkownik nie byl autoryzowany do usuwania, czyli jak klika w delete to przenosi go do strony logowania(domyslne zachowanie)
                //3. zadbaj o to by zwykly uzytkownik nie widzial przycisku delete
            }
        }
    }
}

//Praca domowa 02.10.2018
//Dodaj do adresu status danego adresu Regular, VIP, Critical
//Na liście adresów przy adresie Reugular nie powinno być żadnej ikonki, przy ViP powinna być ikonka VIP, a przy Critical ikonka Critical

    //Przy tworzeniu nowego adresu miej możliwość wybierania statusu adresu poprzez dropdown (lista rozwijana)
    //Oczywiście przy edycji adresu taka lista rozwijana też musi być dostępna
