using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_Barroc_Intens.Data
{
    class IncendentReport
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime DateReported { get; set; }
        public string InitialMessage { get; set; }
        public string CoffeeMachineType { get; set; }
        public string FaultCode { get; set; }
        public bool IsResolved { get; set; }
        public string? FollowUp { get; set; }
        public string IncidentDescription { get; set; }
        public List<Part> UsedParts { get; set; }
    }
}
