using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_Barroc_Intens.Data
{
    internal class PartOrder
    {
        public int PartId { get; set; }
        public Part Part { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime DateTime { get; set; }
    }
}
