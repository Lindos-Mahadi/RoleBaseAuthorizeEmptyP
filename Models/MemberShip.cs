﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConfigureIdentity.Models
{
    public class MemberShip
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}