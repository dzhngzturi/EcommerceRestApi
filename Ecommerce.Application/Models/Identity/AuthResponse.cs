﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Models.Identity
{
    public class AuthResponse
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

    }
}
