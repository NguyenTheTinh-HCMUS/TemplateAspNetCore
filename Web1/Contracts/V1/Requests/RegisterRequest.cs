using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Web1.Helpers.CustomValidationAttribute;

namespace Web1.Contracts.V1.Requests
{
    public class RegisterRequest
    {
        public string FullName { get; set; }
        [EmailUnique]
        [EmailMatch]
        public string Email { get; set; }
        [UsernameUnique]
        public string Username { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; } = null;
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; } = null;
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        //[PasswordPolicy]
        public string Password { get; set; }
        public string AvatarUrl { get; set; }
        public int RoleID { get; set; }
        public int DepartmentId { get; set; }
    }
}
