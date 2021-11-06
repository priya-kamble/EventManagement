using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAPI.Domain
{
    public class User
    {
        public int UserId { get; set; }
        public string UserEmailId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string CellPhone { get; set; }

        public string CellPhone2 { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
