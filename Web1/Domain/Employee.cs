﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web1.Domain
{
    public class Employee
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
        public string PasswordHash { get; set; }
        public string AvatarUrl { get; set; }
        public int RoleID { get; set; }
        public int DepartmentId { get; set; }

        [ForeignKey(nameof(RoleID))]
        public virtual Role Role { set; get; }


        [ForeignKey(nameof(DepartmentId))]
        public virtual Department   Department { set; get; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }

    }
}
