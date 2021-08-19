using Dapper;
using MISA.Core.Interfaces.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace MISA.Infrastructure.Repository
{
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity>

    {
        protected string _tableName;
        protected string _connectString;
        protected IDbConnection _dbConnection;
        DynamicParameters parameter; 
        #region Constructor
        public BaseRepository()
        {
            _tableName = typeof(MISAEntity).Name;
            _connectString = "" +
                "Host = 47.241.69.179;" +
                "Database = MISACukCuk_MF950_LNTHAO;" +
                "User Id = dev;" +
                "Password = 12345678";
            _dbConnection = new MySqlConnection(_connectString);
            parameter = new DynamicParameters();
        }
        #endregion

        public int Add(MISAEntity entity)
        {
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

        public int Delete(Guid entityId)
        {
            parameter.Add($"@{_tableName}Id", entityId.ToString());
            string sqlCommand = $"Proc_Delete{_tableName}ById";
            int rowEffects = _dbConnection.Execute(sqlCommand, param: parameter, commandType: CommandType.StoredProcedure);
            return rowEffects;
        }

        public IEnumerable<MISAEntity> Get()
        {
            string sqlCommand = $"Proc_Get{_tableName}s";
            var entities = _dbConnection.Query<MISAEntity>(sqlCommand, commandType: CommandType.StoredProcedure);
            return entities;
        }

        public MISAEntity GetById(Guid entityId)
        {
            
            parameter.Add($"@{_tableName}Id", entityId.ToString());
            string sqlCommand = $"Proc_Get{_tableName}ById";
            var entity = _dbConnection.QueryFirstOrDefault<MISAEntity>(sqlCommand, param: parameter, commandType: CommandType.StoredProcedure);
            return entity;
        }

        public int Update(MISAEntity entity, Guid entityId)
        {
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
        /// Lấy bản ghi theo thuộc tính
        /// </summary>
        /// <param name="propertyName">Tên thuộc tính</param>
        /// <param name="propertyValue">Giá trị thuộc tính</param>
        /// <returns></returns>
        public MISAEntity GetByProperty(string propertyName, string propertyValue)
        {
            string sqlCommand = $"Proc_Get{_tableName}By{propertyName}";
            parameter.Add("@Value", propertyValue);
            var entity = _dbConnection.QueryFirstOrDefault<MISAEntity>(sqlCommand, param: parameter, commandType: CommandType.StoredProcedure);
            return entity;
        }
    }
}   
