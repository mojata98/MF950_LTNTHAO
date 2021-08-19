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

        public ServiceResult GetById(Guid entityId);

        public ServiceResult Add(MISAEntity entity);

        public ServiceResult Update(MISAEntity entity, Guid entityId);

        public ServiceResult Delete(Guid entityId);

    }
}
