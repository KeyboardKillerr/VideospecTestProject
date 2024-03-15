using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Auth
{
    public class AuthResponseData
    {
        public string AuthToken { get; set; }
        public string ExpirationDateUtc { get; set; }
    }
}
