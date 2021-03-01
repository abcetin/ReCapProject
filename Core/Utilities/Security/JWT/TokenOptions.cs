using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class TokenOptions
    {
        public string Audience { get; set; } //Kullanıcı kitlesi
        public string Issure { get; set; } //İmzalayan
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
