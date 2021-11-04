using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAPI.Domain
{
    public class Organization
    {
        public int OrganizerId { get; set; }
        public string UserEmailId { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }

        public virtual User User { get; set; }
    }
}
