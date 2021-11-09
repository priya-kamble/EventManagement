using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAPI.Domain
{
    public class Location
    {
        public int LocationId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
