using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interfaces.Repository
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// Lấy danh sách khách hàng
        /// </summary>
        /// <returns>Danh sách khách hàng</returns>
        /// CreaatedBy: LNT (15/08)
        List<Customer> Get();
        /// <summary>
        /// Lấy thông tin khách hàng theo Id
        /// </summary>
        /// <param name="customerId">Id khách hàng</param>
        /// <returns>Thông tin 1 khách hàng</returns>
        /// CreatedBy: LNT (15/08)
        Customer GetById(Guid customerId);
        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="customer">Thông tin khách hàng</param>
        /// <returns>Số lượng bản ghi đã thêm</returns>
        /// CreatedBy: LNT (15/08)
        int Add(Customer customer);
        /// <summary>
        /// Cập nhật thông tin khách hàng
        /// </summary>
        /// <param name="customer">Thông tin khách hàng</param>
        /// <param name="customerId">Id khách hàng</param>
        /// <returns>Số lượng bản ghi cập nhật</returns>
        /// CreatedBy: LNT (15/08)
        int Update(Customer customer, Guid customerId);
        /// <summary>
        /// Xóa thông tin khách hàng
        /// </summary>
        /// <param name="customerId">Id khách hàng</param>
        /// <returns>Số lượng bản ghi đã xóa</returns>
        /// CreatedBy: LNT (15/08)
        int Delete(Guid customerId);
    }
}
