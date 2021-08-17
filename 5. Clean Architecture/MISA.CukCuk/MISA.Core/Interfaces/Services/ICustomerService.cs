using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interfaces.Services
{
    public interface ICustomerService
    {
        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="customer">Thông tin khách hàng</param>
        /// <returns>ServiceResult - Kết quả trẩ về xử lý nghiệp vụ</returns>
        /// CreatedBy: LNT (15/08)
        ServiceResult Add(Customer customer);
        /// <summary>
        /// Cập nhật thông tin khách hàng
        /// </summary>
        /// <param name="customer">Thông tin khách hàng</param>
        /// <param name="customerId">Id khách hàng</param>
        /// <returns>ServiceResult - Kết quả trẩ về xử lý nghiệp vụ</returns>
        /// CreatedBy: LNT (15/08)
        ServiceResult Update(Customer customer, Guid customerId);
        /// <summary>
        /// Lấy danh sách khách hàng
        /// </summary>
        /// <returns>ServiceResult - Kết quả trẩ về xử lý nghiệp vụ</returns>
        /// CreatedBy: LNT (15/08)
        ServiceResult Get();
        /// <summary>
        /// Lấy thông tin khách hàng theo Id
        /// </summary>
        /// <param name="customerId">Id khách hàng</param>
        /// <returns>ServiceResult - Kết quả trẩ về xử lý nghiệp vụ</returns>
        /// CreatedBy: LNT (15/08)
        ServiceResult GetById(Guid customerId);
        /// <summary>
        /// Xóa thông tin khách hàng
        /// </summary>
        /// <param name="customerId">Id khách hàng</param>
        /// <returns>ServiceResult - Kết quả trẩ về xử lý nghiệp vụ</returns>
        /// CreatedBy: LNT (15/08)
        ServiceResult Delete(Guid customerId);
    }
}
