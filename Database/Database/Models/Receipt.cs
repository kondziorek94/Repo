using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Receipt
    {
        public Guid Id { get; set; }
        public string ServiceName {get; set;}
        public decimal Total { get; set; }
        public virtual Client Client { get; set; }
    }
}
