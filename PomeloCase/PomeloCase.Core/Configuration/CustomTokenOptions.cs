using System;
using System.Collections.Generic;

namespace PomeloCase.Core.Configuration
{
    public class CustomTokenOptions
    {
        public List<string> Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }

        public string SecurityKey { get; set; }
    }
}