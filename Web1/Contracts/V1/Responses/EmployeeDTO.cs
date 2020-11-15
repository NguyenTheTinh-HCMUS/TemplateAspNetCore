using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web1.Contracts.V1.Responses
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; } = null;
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; } = null;
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string AvatarUrl { get; set; }
        public int RoleID { get; set; }
        public int DepartmentId { get; set; }
        public virtual DepartmentDTO Department { set; get; }



    }
}
