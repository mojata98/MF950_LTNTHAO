using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interfaces.Repository
{
    public interface IBaseRepository<MISAEntity>
    {
        /// <summary>
        /// Lấy toàn bộ danh sách
        /// </summary>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy: LNT (17/08)
        public IEnumerable<MISAEntity> Get();

        /// <summary>
        /// Lấy thông tin theo ID
        /// </summary>
        /// <param name="entityId">ID khách hàng</param>
        /// <returns>Thông tin theo ID</returns>
        /// CreatedBy: LNT (17/08)
        public MISAEntity GetById(Guid entityId);

        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="entity">Thông tin thêm mới</param>
        /// <returns></returns>
        /// CreatedBy: LNT (17/08)
        public int Add(MISAEntity entity);

        /// <summary>
        /// Cập nhật thông tin khách hàng
        /// </summary>
        /// <param name="entity">Thông tin cập nhật</param>
        /// <param name="entityId">ID khách hàng cập nhật</param>
        /// <returns></returns>
        /// CreatedBy: LNT (17/08)
        public int Update(MISAEntity entity, Guid entityId);

        /// <summary>
        /// Xóa thông tin khách hàng theo ID
        /// </summary>
        /// <param name="entityId">ID khách hàng cần xóa</param>
        /// <returns></returns>
        /// CreatedBy: LNT (17/08)
        public int Delete(Guid entityId);

        /// <summary>
        /// Lấy mã mới từ database
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: LNT (19/07)
        public string GetNewCode();

        /// <summary>
        /// Sinh tự động mã mới
        /// </summary>
        /// <param name="oldCode"></param>
        /// <returns></returns>
        public string GenerateNewCode(string oldCode);

        /// <summary>
        /// Lấy danh sách bản ghi theo tên thuộc tính 
        /// </summary>
        /// <param name="propertyName">Tên thuộc tính</param>
        /// <param name="propertyValue">Giá trị thuộc tính</param>
        /// <returns></returns>
        /// CreatedBy: LNT (19/08)
        public MISAEntity GetByProperty(string propertyName, string propertyValue);
    }
}
