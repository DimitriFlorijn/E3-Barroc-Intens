using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_Barroc_Intens.Data
{
    internal class Storage
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
        public int? BeanId { get; set; }
        public Bean Bean { get; set; }
        public int? PartId { get; set; }
        public Part Part { get; set; }
        public int Amount { get; set; }

    }
}
