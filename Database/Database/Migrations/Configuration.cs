namespace Database.Migrations
{
    using Database.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AppDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AppDBContext context)
        {
            Guid guid1 = new Guid("DA67A45D-14B7-4473-97CE-9C62ECC8155E");
            Guid guid2 = new Guid("2F67CE58-1AC6-4699-84DE-EA462D04CC32");
            Guid guid3 = new Guid("13CAA879-8E49-4B91-994F-26220554982E");

            Client client = new Client() {Id=guid1,Name="Jan Kowalski" };
            Receipt shopping = new Receipt() { Id=guid2, ServiceName="Shopping",Total=92.10M};
            Receipt fuel = new Receipt() { Id = guid3, ServiceName="Gas Station",Total=86.87M };
            context.Clients.AddOrUpdate(client);
            context.Receipts.AddOrUpdate(shopping);
            context.Receipts.AddOrUpdate(fuel);
            context.SaveChanges();
            client = context.Clients.Find(guid1);
            shopping = context.Receipts.Find(guid2);
            fuel = context.Receipts.Find(guid3);
            shopping.Client = client;
            fuel.Client = client;
            context.SaveChanges();

        }
    }
}
