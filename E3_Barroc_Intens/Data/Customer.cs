using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_Barroc_Intens.Data
{
    internal class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Number { get; set; }
        public bool BkrRegistered { get; set; }
        public List<CustomerOrder> Orders { get; set; } = new List<CustomerOrder>();
        public List<Contract> contracts { get; set; } = new List<Contract>();
    }
}
