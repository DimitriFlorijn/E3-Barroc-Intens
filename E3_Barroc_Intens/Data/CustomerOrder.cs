using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_Barroc_Intens.Data
{
    public class CustomerOrder
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
        public int? BeanId { get; set; }
        public Bean Bean { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsPaid { get; set; }
    }
}
