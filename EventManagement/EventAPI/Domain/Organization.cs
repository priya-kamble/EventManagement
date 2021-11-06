using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAPI.Domain
{
    public class Organization
    {
        public int OrganizerId { get; set; }
             
        public string OrganizationName { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
