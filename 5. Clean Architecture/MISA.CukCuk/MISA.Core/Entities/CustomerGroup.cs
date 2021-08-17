using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    public class CustomerGroup
    {
        #region
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid CustomerGroupId { get; set; }
        /// <summary>
        /// Tên
        /// </summary>
        public string CustomerGroupName { get; set; }
        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }

        #endregion
    }
}
