using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_API.DataTypes.Models.DTOs
{
    public class EntraOptions
    {
        public string Instance {get; set;} = "https://login.microsoftonline.com/";
        public string TenantId {get; set;} = string.Empty;
        public string ClientId {get; set;} = string.Empty;
        public string ClientSecret {get; set;} = string.Empty;
        public string Audience {get; set;} = string.Empty;
        // Full scope URI from "Expose an API" e.g. api://{clientId}/access_as_user
        public string Scope {get; set;} = string.Empty;
    }
}