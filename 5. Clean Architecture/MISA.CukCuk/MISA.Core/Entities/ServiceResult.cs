using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    public class ServiceResult
    {
        /// <summary>
        /// Thông tin trả về có hợp lệ hay không?
        /// CreatedBy: LNT (15/08)
        /// </summary>
        public bool IsValid { get; set; } = true;
        /// <summary>
        /// Dữ liệu trả về
        /// CreatedBy: LNT (15/08)
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// Thông báo trả về
        /// CreatedBy: LNT (15/08)
        /// </summary>
        public string Message { get; set; }
    }
}
