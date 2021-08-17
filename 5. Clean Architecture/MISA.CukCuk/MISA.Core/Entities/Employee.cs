using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    public class Employee:BaseEntity
    {
        public Guid EmployeeId { get; set; }

        public string EmployeeCode { get; set; }

        public string FullName { get; set; }

        public int Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public DateTime JoinDate { get; set; }

        public string IdentityNumber { get; set; }

        public DateTime IdentityDate { get; set; }

        public string IdentityPlace { get; set; }

        public int WorkStatus { get; set; }

        public Double Salary { get; set; }

        
    }
}
