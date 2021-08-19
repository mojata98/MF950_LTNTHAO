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
        /// <returns></returns>
        /// CreatedBy: LNT (17/08)
        public IEnumerable<MISAEntity> Get();

        public MISAEntity GetById(Guid entityId);

        public int Add(MISAEntity entity);

        public int Update(MISAEntity entity, Guid entityId);

        public int Delete(Guid entityId);

        /// <summary>
        /// Lấy danh sách bản ghi theo tên thuộc tính 
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="propertyValue"></param>
        /// <returns></returns>
        
        public MISAEntity GetByProperty(string propertyName, string propertyValue);
    }
}
