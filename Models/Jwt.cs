using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace refund.Models
{
    public class Jwt
    {
        public string? Key { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public string? Subject { get; set; }
        public string? Expire { get; set; }




    }
}