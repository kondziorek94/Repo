namespace DatabaseFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Invoice
    {
        public Guid Id { get; set; }

        public double TaxNumber { get; set; }

        public Guid? Client_Id { get; set; }

        public virtual Client Client { get; set; }

        public virtual Receipt Receipt { get; set; }
    }
}
