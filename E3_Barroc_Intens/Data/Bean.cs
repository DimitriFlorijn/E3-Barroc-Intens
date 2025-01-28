using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_Barroc_Intens.Data
{
    public class Bean
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal PricePerKg { get; set; }
        public List<Contract> Contracts { get; set; } = new List<Contract>();
        public List<CustomerOrder> Costumers { get; set; } = new List<CustomerOrder>();
    }
}
