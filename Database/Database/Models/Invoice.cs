using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    [Table("Invoices")]
    public class Invoice:Receipt
    {
        public double TaxNumber { get; set; }
    }
}
