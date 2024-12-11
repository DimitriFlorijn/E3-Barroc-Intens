using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_Barroc_Intens.Data
{
    internal class Appointment
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Customer Client { get; set; }
        public DateTime DateTime { get; set; }
        public string Notes { get; set; }
    }
}