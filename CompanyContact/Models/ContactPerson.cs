using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyContact.Models
{
    public class ContactPerson
    {
        public int ContactPersonId { get; set; }
      
        public string FirstName { get; set; }

        public string LasttName { get; set; }

        public String Email { get; set; }

        public int PhoneNumver { get; set; }
        public ICollection<Company> companies { get; set; }
    }
}
