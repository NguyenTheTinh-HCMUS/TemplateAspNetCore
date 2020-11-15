using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web1.Contracts.V1.Responses
{
    public class AuthResult
    {
       
        public string Email { get; set; }
        public string Username { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string[] Errors { get; set; }
    }
}
