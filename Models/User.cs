using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_assessment.Models
{
    public class User
    {
        public int ID { get; set; }
        public string FriendlyName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string Company { get; set; }
        public bool CanLogin { get; set; }
    }
}
