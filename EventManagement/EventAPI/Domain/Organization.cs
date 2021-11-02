﻿using EventAPI.Properties.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAPI.Domain
{
    public class Organization
    {
        public int OrganizerId { get; set; }
        public string UserName { get; set; }
        public string Contacts { get; set; }
        public string Address { get; set; }

        public virtual User User { get; set; }
       
    }
}
