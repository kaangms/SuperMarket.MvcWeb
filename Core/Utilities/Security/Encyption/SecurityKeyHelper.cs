﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encyption
{
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            SymmetricSecurityKey result = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            return result;
        }
    }
}
