using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    public class BaseEntity
    {
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Ngày sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// Người sửa
        /// </summary>
        public string ModifiedBy { get; set; }
    }
    //---------------------------------------------
    /// <summary>
    /// Required yêu cầu không để trống
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class Required : Attribute
    {
    }

    /// <summary>
    /// Duplication thông báo thông tin không được trùng
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class Duplication : Attribute
    {

    }

    /// <summary>
    /// Email yêu cầu thông tin email phải đúng 
    /// </summary>
    public class Email : Attribute
    {

    }
}
