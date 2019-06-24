namespace DatabaseFirst
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AppDatabaseModel : DbContext
    {
        public AppDatabaseModel()
            : base("name=AppDatabaseModelADO")
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasMany(e => e.Invoices)
                .WithOptional(e => e.Client)
                .HasForeignKey(e => e.Client_Id);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Receipts)
                .WithOptional(e => e.Client)
                .HasForeignKey(e => e.Client_Id1);

            modelBuilder.Entity<Receipt>()
                .HasOptional(e => e.Invoice)
                .WithRequired(e => e.Receipt);
        }
    }
}
