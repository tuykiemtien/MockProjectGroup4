﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AccountDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string CustomerId { get; set; }
        public Nullable<int> EmployeeId { get; set; }

        public virtual CustomerDTO Customer { get; set; }
        public virtual EmployeeDTO Employee { get; set; }
    }
}
