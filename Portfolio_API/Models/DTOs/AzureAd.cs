using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_API.Models.DTOs
{
    public class AzureAd
    {
        public string Instance {get; set;} = "https://login.microsoftonline.com/";
        public string TenantId {get; set;} = string.Empty;
        public string ClientId {get; set;} = string.Empty;
        public string ClientSecret {get; set;} = string.Empty;
        public string Audience {get; set;} = string.Empty;
        
    }
}