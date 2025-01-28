using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_Barroc_Intens.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public decimal InstallationCost { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public List<Contract> contracts { get; set; } = new List<Contract>();
        public List<CustomerOrder> costumers { get; set; } = new List<CustomerOrder>();
    }
}
