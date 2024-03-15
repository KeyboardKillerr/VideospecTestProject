using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Auth
{
    internal class AuthRequestBody
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
