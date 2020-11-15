
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web1.Contracts.V1.Requests
{
    public class DepartmentRequest
    {
        [Required]
        public string DepartmentName { get; set; }
        public string Description { get; set; }
    }
}
