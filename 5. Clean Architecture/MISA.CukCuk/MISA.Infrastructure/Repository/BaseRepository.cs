using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Core.Interfaces.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace MISA.Infrastructure.Repository
{
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity>, IDisposable

    {
        #region Declare
        IConfiguration _configuration;
        protected string _tableName;
        protected string _connectString = null;
        protected IDbConnection _dbConnection;
        DynamicParameters parameter;
        #endregion

        #region Constructor
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _tableName = typeof(MISAEntity).Name;
            _connectString = _configuration.GetConnectionString("MISACukCuk");
            _dbConnection = new MySqlConnection(_connectString);
            parameter = new DynamicParameters();
        }
        #endregion

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="entity">Thông tin thêm mới</param>
        /// <returns></returns>
        /// CreatedBy: LNT (19/08)
        public virtual int Add(MISAEntity entity)
        {
            parameter = new DynamicParameters();
            string sqlCommand = $"Proc_Insert{_tableName}";
            foreach (PropertyInfo prop in entity.GetType().GetProperties())
            {
                var value = (prop.GetValue(entity) == "") ? null : prop.GetValue(entity);
                parameter.Add($"@{prop.Name}", value);
            }
            _dbConnection.Open();
            using (var transaction = _dbConnection.BeginTransaction())
            {
                int rowAffects = _dbConnection.Execute(sqlCommand, param: parameter, transaction, commandType: CommandType.StoredProcedure);
                transaction.Commit();
                return rowAffects;
            }
        }

        /// <summary>
        /// Xóa thông tin theo ID
        /// </summary>
        /// <param name="entityId">ID cần xóa thông tin</param>
        /// <returns></returns>
        /// CreatedBy: LNT (19/08)
        public virtual int Delete(Guid entityId)
        {
            parameter = new DynamicParameters();
            parameter.Add($"@{_tableName}Id", entityId.ToString());
            string sqlCommand = $"Proc_Delete{_tableName}ById";
            int rowEffects = _dbConnection.Execute(sqlCommand, param: parameter, commandType: CommandType.StoredProcedure);
            return rowEffects;
        }

        /// <summary>
        /// Lấy danh sách thông tin
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: LNT (19/08)
        public virtual IEnumerable<MISAEntity> Get()
        {
            parameter = new DynamicParameters();
            string sqlCommand = $"Proc_Get{_tableName}s";
            var entities = _dbConnection.Query<MISAEntity>(sqlCommand, commandType: CommandType.StoredProcedure);
            return entities;
        }

        /// <summary>
        /// Lấy thông tin từ ID
        /// </summary>
        /// <param name="entityId">ID cần lấy thông tin</param>
        /// <returns></returns>
        public virtual MISAEntity GetById(Guid entityId)
        {
            parameter = new DynamicParameters();
            parameter.Add($"@{_tableName}Id", entityId.ToString());
            string sqlCommand = $"Proc_Get{_tableName}ById";
            var entity = _dbConnection.QueryFirstOrDefault<MISAEntity>(sqlCommand, param: parameter, commandType: CommandType.StoredProcedure);
            return entity;
        }

        /// <summary>
        /// Cập nhật thông tin 
        /// </summary>
        /// <param name="entity">Thông tin cập nhật</param>
        /// <param name="entityId">ID cần cập nhật</param>
        /// <returns></returns>
        /// CreatedBy: LNT (19/08)
        public virtual int Update(MISAEntity entity, Guid entityId)
        {
            parameter = new DynamicParameters();
            string sqlCommand = $"Proc_Update{_tableName}";
            foreach (PropertyInfo prop in entity.GetType().GetProperties())
            {
                var value = prop.GetValue(entity) == "" ? null : prop.GetValue(entity);
                parameter.Add($"@{prop.Name}", value);
            }
            parameter.Add($"@{_tableName}Id", entityId.ToString());
            _dbConnection.Open();
            using (var transaction = _dbConnection.BeginTransaction())
            {
                int rowAffects = _dbConnection.Execute(sqlCommand, param: parameter, transaction, commandType: CommandType.StoredProcedure);
                transaction.Commit();
                return rowAffects;
            }
        }
        /// <summary>
        /// Lấy mã mới 
        /// </summary>
        /// <returns></returns>
        public virtual string GetNewCode()
        {
            string oldCode = _dbConnection.QueryFirstOrDefault<string>($"Proc_GetNew{_tableName}Code", commandType: CommandType.StoredProcedure);
            string newCode = GenerateNewCode(oldCode);
            return newCode;
        }

        /// <summary>
        /// Lấy bản ghi theo thuộc tính
        /// </summary>
        /// <param name="propertyName">Tên thuộc tính</param>
        /// <param name="propertyValue">Giá trị thuộc tính</param>
        /// <returns></returns>
        public virtual MISAEntity GetByProperty(string propertyName, string propertyValue)
        {
            parameter = new DynamicParameters();
            string sqlCommand = $"Proc_Get{_tableName}By{propertyName}";
            parameter.Add($"{propertyName}", propertyValue);
            var entity = _dbConnection.QueryFirstOrDefault<MISAEntity>(sqlCommand, param: parameter, commandType: CommandType.StoredProcedure);
            return entity;
        }

        /// <summary>
        /// Tạo mã mới
        /// </summary>
        /// <param name="oldCode">Mã nhân viên cũ</param>
        /// <returns></returns>
        /// CreatedBy : LP(12/8)
        public virtual string GenerateNewCode(string oldCode)
        {
            string changeValue = "";
            int plus = 1;
            int brk = 0;
            for (int i = oldCode.Length - 1; i >= 0; i--)
            {
                brk = i;
                if (oldCode[i] >= '0' && oldCode[i] <= '9')
                {
                    int n = (int)(oldCode[i] - '0');
                    if (n + plus >= 10)
                    {
                        int v = (n + plus) - 10;
                        plus = 1;
                        changeValue = v.ToString() + changeValue;
                    }
                    else
                    {
                        changeValue = (n + plus).ToString() + changeValue;
                        break;
                    }
                }
                else
                {
                    brk += 1;
                    changeValue = plus.ToString() + changeValue;
                    break;
                }
            }
            return oldCode.Substring(0, brk) + changeValue;
        }

        /// <summary>
        /// Hủy kết nối DATABASE
        /// </summary>
        public void Dispose()
        {
            _dbConnection.Dispose();
        }
    }
}   
