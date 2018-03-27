using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyContact.Models
{
    public class Common
    {
        public IEnumerable<Company> Companies { get; set; }
        public IEnumerable<ContactPerson> ContactPerson { get; set; }
    }
}
