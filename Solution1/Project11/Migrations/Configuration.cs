using Project11.DAL;
using Project11.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace Project11.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Project11.DAL.StudentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        public static void Seed()
        {
            StudentContext context = new StudentContext();
            Guid guid1 = new Guid("AC9D1A51-1068-4958-911F-7347CAFE5256");
            Guid guid2 = new Guid("C526C690-06F4-4613-8BA7-7D0D13610AB9");
            Guid guid3 = new Guid("FF54B99C-C7A5-4BC3-99C8-8116529C909E");
            Student student1 = new Student { StudentId = guid1, Name = "Adam", Activities = new List<Activity>() },
                student2 = new Student { StudentId = guid2, Name = "Romek", Activities = new List<Activity>() },
                student3 = new Student { StudentId = guid3, Name = "Stanislaw", Activities = new List<Activity>() };

            context.Students.AddOrUpdate(s => s.StudentId, new Student[] {
                student1,
                student2,
                student3
            });
            context.SaveChanges();
            Guid guid4 = new Guid("18D880E0-9E38-469F-8605-AF9269D1237D");
            Guid guid5 = new Guid("D930B8DE-3A3A-44C8-B86C-2B71757F64E2");
            Guid guid6 = new Guid("10C8D5C3-90CE-440F-BA07-C2138A5EADE2");
            Activity a1 = new Activity { ActivityId = guid4, Name = "Basen", Cost = 13.25, Students = new List<Student>() { student1, student2 } },
            a2 = new Activity { ActivityId = guid5, Name = "Lyzwy", Cost = 5.00, Students = new List<Student>() { student1 } },
            a3 = new Activity { ActivityId = guid6, Name = "Strzelnaie z luku", Cost = 15.00, Students = new List<Student>() { student3, student2 } };
            context.Activities.AddOrUpdate(a => a.ActivityId, new Activity[] { a1, a2, a3 });
            context.SaveChanges();
        }
        protected override void Seed(Project11.DAL.StudentContext context)
        {
        }
    }
}