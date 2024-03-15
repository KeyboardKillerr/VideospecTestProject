using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Error
{
    public class ErrorResponse
    {
        public string Status { get; set; }
        public ErrorResponseData Error { get; set; }
    }
}
