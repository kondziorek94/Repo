using Project11.Models;
using System.Data.Entity;

namespace Project11.DAL
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Activity> Activities { get; set; }

        public StudentContext(): base("defConnectionString") { }
    }
}