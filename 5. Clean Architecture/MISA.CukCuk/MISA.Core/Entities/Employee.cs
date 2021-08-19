using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    public class Employee:BaseEntity
    {
        public Guid EmployeeId { get; set; }
        [Required]
        [Duplication]
        public string EmployeeCode { get; set; }
        [Required]
        public string FullName { get; set; }

        public int? Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }
        [Required]
        [Duplication]
        public string PhoneNumber { get; set; }
        [Required]
        [Duplication]
        [Email]
        public string Email { get; set; }

        public string Address { get; set; }

        public DateTime JoinDate { get; set; }
        [Required]
        [Duplication]
        public string IdentityNumber { get; set; }

        public DateTime IdentityDate { get; set; }

        public string IdentityPlace { get; set; }

        public int? WorkStatus { get; set; }

        public Double Salary { get; set; }

        public string FirstName { get; set; }

        /// <summary>
        /// Tên
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Tình trạng hôn nhân
        /// </summary>
        public int? MartialStatus { get; set; }


        /// <summary>
        /// Trình độ giáo dục
        /// </summary>
        public string EducationalBackground { get; set; }

        /// <summary>
        /// Chất lượng 
        /// </summary>
        public Guid? QualificationId { get; set; }

        /// <summary>
        /// Mã số thuế cá nhân
        /// </summary>
        public string PersonalTaxCode { get; set; }

        /// <summary>
        /// Mã phòng ban
        /// </summary>
        public Guid? DepartmentId { get; set; }

        /// <summary>
        /// Mã vị trí
        /// </summary>
        public Guid? PositionId { get; set; }
    }
}
