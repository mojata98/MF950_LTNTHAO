using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interfaces.Services
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        
        /// <summary>
        /// Thêm mới mã tự động
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: LNT(19/08)
        //public ServiceResult GetNewEmployeeCode();

        /// <summary>
        /// Lọc thông tin nhân viên theo thuộc tính
        /// </summary>
        /// <param name="name">Tên thuộc tính</param>
        /// <param name="value">Giá trị thuộc tính</param>
        /// <returns></returns>
        /// CreatedBy: LNT (19/08)
        //public ServiceResult GetEmployeeByProperty(string name, string value);

    }
}
