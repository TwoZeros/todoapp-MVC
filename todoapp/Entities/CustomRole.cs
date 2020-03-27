﻿using Identity.Dapper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoapp.Entities
{
    public class CustomRole : DapperIdentityRole
    {
        public bool IsDummy { get; set; }

        public CustomRole() { }
        public CustomRole(string roleName) : base(roleName)
        {
        }
    }
}
