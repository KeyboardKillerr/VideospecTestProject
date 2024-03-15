using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Auth
{
    public class AuthResponse
    {
        public string Status { get; set; }
        public AuthResponseData Data { get; set; }
    }
}
