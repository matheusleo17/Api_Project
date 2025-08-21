using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serverT2.Communication.Responses
{
    public class ResponseRegisterdUserJson
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string Password {  get; set; } = string.Empty;
    }
}
