using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_Barroc_Intens.Data
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Part> Parts { get; set; } = new List<Part>();
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Bean> Beans { get; set; } = new List<Bean>();
    }
}
