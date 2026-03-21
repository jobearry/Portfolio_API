using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_API.DataTypes.Models.DTOs
{
    public class JwtOptions
    {
        public string Key {get; set;} = string.Empty;
        public string Issuer {get; set;} = string.Empty;
        public string Audience {get; set;} = string.Empty;
        public int Expires {get; set;} = 60;
    }
}