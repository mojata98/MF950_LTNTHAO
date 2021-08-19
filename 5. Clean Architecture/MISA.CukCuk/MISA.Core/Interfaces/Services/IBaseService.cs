using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interfaces.Services
{
    public interface IBaseService<MISAEntity>
    {
        /// <summary>
        /// Lấy tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        /// CreatedBy: LNT (17/08)
        public ServiceResult Get();
        /// <summary>
        /// Lấy thông tin theo ID
        /// </summary>
        /// <param name="entityId">ID khách hàng</param>
        /// <returns>Thông tin theo ID</returns>
        /// CreatedBy: LNT (17/08)
        public ServiceResult GetById(Guid entityId);
        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="entity">Thông tin thêm mới</param>
        /// <returns></returns>
        /// CreatedBy: LNT (17/08)
        public ServiceResult Add(MISAEntity entity);
        /// <summary>
        /// Cập nhật thông tin khách hàng
        /// </summary>
        /// <param name="entity">Thông tin cập nhật</param>
        /// <param name="entityId">ID khách hàng cập nhật</param>
        /// <returns></returns>
        /// CreatedBy: LNT (17/08)
        public ServiceResult Update(MISAEntity entity, Guid entityId);
        /// <summary>
        /// Xóa thông tin khách hàng theo ID
        /// </summary>
        /// <param name="entityId">ID khách hàng cần xóa</param>
        /// <returns></returns>
        /// CreatedBy: LNT (17/08)
        public ServiceResult Delete(Guid entityId);

        public ServiceResult GetNewCode();

        public ServiceResult GetByProperty(string name, string value);

    }
}
