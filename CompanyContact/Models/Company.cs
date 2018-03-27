using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyContact.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
      
        public int ContactPersonId { get; set; }

        public ContactPerson ContactPerson { get; set; }
    }
}
