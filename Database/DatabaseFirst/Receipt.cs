namespace DatabaseFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Receipt
    {
        public Guid Id { get; set; }

        public string ServiceName { get; set; }

        public decimal Total { get; set; }

        public Guid? Client_Id1 { get; set; }

        public virtual Client Client { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}
