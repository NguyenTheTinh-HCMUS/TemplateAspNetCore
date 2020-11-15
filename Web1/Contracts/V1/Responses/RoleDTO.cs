using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web1.Contracts.V1.Responses
{
    public class RoleDTO
    {
        public int RoleId { set; get; }
        public string RoleName { set; get; }
        public bool Status { set; get; }
    }
}
