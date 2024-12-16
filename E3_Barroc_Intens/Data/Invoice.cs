using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace E3_Barroc_Intens.Data
{
    internal class Invoice
    {
        public int Id { get; set; }

        public int ContractId { get; set; }
        public Contract Contract { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsPaid { get; set; }
    }
}
