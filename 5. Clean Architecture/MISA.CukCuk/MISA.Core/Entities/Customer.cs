﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    public class Customer
    {
        #region Property
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid CustomerId { get; set; }
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public string CustomerCode { get; set; }
        ///// <summary>
        ///// Họ
        ///// </summary>
        //public string FirstName { get; set; }
        ///// <summary>
        ///// Tên
        ///// </summary>
        //public string LastName { get; set; }
        /// <summary>
        /// Tên đầy đủ
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Gender { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        #endregion
    }
}
