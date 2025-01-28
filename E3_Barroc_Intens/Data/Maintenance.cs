using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_Barroc_Intens.Data
{
    public class Maintenance
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CostumerId { get; set; }
        public Customer Costumer { get; set; }
        public string Description { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
