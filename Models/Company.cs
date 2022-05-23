using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_assessment.Models
{
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public bool Active { get; set; }
    }
}
