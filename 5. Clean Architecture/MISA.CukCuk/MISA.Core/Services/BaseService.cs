using MISA.Core.Entities;
using MISA.Core.Enumerations;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MISA.Core.Services
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity>

    {
        protected IBaseRepository<MISAEntity> _baseRepository;
        ServiceResult _serviceResult;

        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult();
        }

        public ServiceResult Add(MISAEntity entity)
        {
            _serviceResult = CheckValidate(entity);
            _serviceResult.MoreInfo = Properties.Resource.POST;
            if (_serviceResult.ResultCode == (int)EnumServiceResult.Created)
            {
                try
                {
                    int rowEffects = _baseRepository.Add(entity);
                    if (rowEffects > 0)
                    {
                        _serviceResult.SetSuccess(_serviceResult, rowEffects);
                        _serviceResult.ResultCode = (int)EnumServiceResult.Created;
                    }
                    else
                    {
                        _serviceResult.SetNoContent(_serviceResult);
                    }
                }
                catch (Exception ex)
                {
                    _serviceResult.SetInternalServerError(_serviceResult);
                    _serviceResult.DevMessage.Add($"Exception {ex.Message}");
                }

            }
            return _serviceResult;
            
        }

        public ServiceResult Delete(Guid entityId)
        {
            _serviceResult.MoreInfo = Properties.Resource.DELETE;
            try
            {
                int rowEffects = _baseRepository.Delete(entityId);
                if (rowEffects > 0)
                {
                    _serviceResult.SetSuccess(_serviceResult, rowEffects);
                }
                else
                {
                    _serviceResult.SetBadRequest(_serviceResult);
                    _serviceResult.DevMessage.Add($"{entityId.ToString()} xóa không thành công");
                }
            }
            catch (Exception ex)
            {
                _serviceResult.SetInternalServerError(_serviceResult);
                _serviceResult.DevMessage.Add($"Exception {ex.Message}");
            }
            return _serviceResult;
            //_serviceResult.Data = _baseRepository.Delete(entityId);
            //return _serviceResult;
        }

        public ServiceResult Get()
        {
            _serviceResult.MoreInfo = Properties.Resource.GET;
            try
            {
                var result = _baseRepository.Get();
                if (result.Count() > 0)
                {
                    _serviceResult.SetSuccess(_serviceResult, result);
                }
                else
                {
                    _serviceResult.SetNoContent(_serviceResult);
                }

            }
            catch (Exception ex)
            {
                _serviceResult.SetInternalServerError(_serviceResult);
                _serviceResult.DevMessage.Add($"Exception {ex.Message}");
            }
            return _serviceResult;
        }

        public ServiceResult GetById(Guid entityId)
        {
            _serviceResult.MoreInfo = Properties.Resource.GET;
            try
            {
                var result = _baseRepository.GetById(entityId);

                if (result != null)
                {
                    _serviceResult.SetSuccess(_serviceResult, result);
                }
                else
                {
                    _serviceResult.SetBadRequest(_serviceResult);
                    _serviceResult.DevMessage.Add($"Lấy mã {entityId.ToString()} không thành công");
                }
            }
            catch (Exception ex)
            {
                _serviceResult.SetInternalServerError(_serviceResult);
                _serviceResult.DevMessage.Add($"Exception {ex.Message}");
            }
            return _serviceResult;
            //_serviceResult.Data = _baseRepository.GetById<MISAEntity>(entityId);
            //return _serviceResult;
        }

        public ServiceResult Update(MISAEntity entity, Guid entityId)
        {
            _serviceResult.MoreInfo = Properties.Resource.PUT;
            try
            {
                int rowEffects = _baseRepository.Update(entity, entityId);
                if (rowEffects > 0)
                {
                    _serviceResult.SetSuccess(_serviceResult, rowEffects);
                }
                else
                {
                    _serviceResult.SetNoContent(_serviceResult);
                }
            }
            catch (Exception ex)
            {
                _serviceResult.SetInternalServerError(_serviceResult);
                _serviceResult.DevMessage.Add($"Exception: {ex.Message}");
            }
            return _serviceResult;
            //_serviceResult.Data = _baseRepository.Update(entity, entityId);
            //return _serviceResult;
        }

        //============================Nghiệp vụ bình thường============================
        /// <summary>
        /// Kiểm tra đầu vào dữ liệu 
        /// </summary>
        /// <param name="entity">Thông tin đối tượng </param>
        /// <returns>Thông tin sau khi validate</returns>
        
        private ServiceResult CheckValidate(MISAEntity entity)
        {
            //ServiceResult serviceResult = new ServiceResult();
            try
            {
                foreach (var property in entity.GetType().GetProperties())
                {
                    var name = property.Name;
                    var value = (property.GetValue(entity) == "") ? null : property.GetValue(entity);
                    if (property.IsDefined(typeof(Required), false) && IsNull(value))
                    {
                        _serviceResult.ResultCode = (int)EnumServiceResult.BadRequest;
                        _serviceResult.DevMessage.Add($"Giá trị {name} không được để trống");
                        _serviceResult.UserMessage = $"Giá trị {name} không được để trống";
                        return _serviceResult;
                    }

                    if (property.IsDefined(typeof(Duplication), false) && IsDuplication(name, (string)value))
                    {
                        _serviceResult.ResultCode = (int)EnumServiceResult.BadRequest;
                        _serviceResult.DevMessage.Add($"Giá trị {name} đã tồn tại");
                        _serviceResult.UserMessage = $"Giá trị {name} đã tồn tại";
                        return _serviceResult;
                    }

                    if (property.IsDefined(typeof(Email), false))
                    {
                        if (IsNotEmail(value.ToString().Trim()))
                        {
                            _serviceResult.ResultCode = (int)EnumServiceResult.BadRequest;
                            _serviceResult.DevMessage.Add($"Giá trị {name} không đúng định dạng");
                            _serviceResult.UserMessage = $"Giá trị {name} không đúng định dạng";
                            return _serviceResult;
                        }
                        
                    }
                }
                _serviceResult.ResultCode = (int)EnumServiceResult.Created;
            }
            catch (Exception ex)
            {
                _serviceResult.SetInternalServerError(_serviceResult);
                _serviceResult.DevMessage.Add($"Exception {ex.Message}");
            }
            return _serviceResult;
        }

        /// <summary>
        /// Kiểm tra giá trị null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool IsNull(object value)
        {
            if (string.IsNullOrEmpty(Convert.ToString(value)) || value == null) return true;
            return false;
        }

        /// <summary>
        /// Kiểm tra trùng với giá trị có trước
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool IsDuplication(string name, string value)
        {
            var entityDuplicate = _baseRepository.GetByProperty(name, value);
            if (entityDuplicate != null) return true;
            return false;
        }

        /// <summary>
        /// Kiểm tra định dạng email
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool IsNotEmail(string email)
        {
            string pattern = @"^((\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)\s*[;,.]{0,1}\s*)+$";
            Regex regex = new Regex(pattern);

            if (regex.Matches(email).Count == 0)
                return true;
            return false;

        }

        public ServiceResult GetNewCode()
        {
            
            _serviceResult.MoreInfo = Properties.Resource.GET;
            try
            {
                var employee = _baseRepository.GetNewCode();
                if (employee != null)
                {
                    _serviceResult.SetSuccess(_serviceResult, employee);
                }
                else
                {
                    _serviceResult.SetNoContent(_serviceResult);
                }
            }
            catch (Exception ex)
            {
                _serviceResult.SetInternalServerError(_serviceResult);
                _serviceResult.DevMessage.Add($"Exception: {ex.Message}");
            }
            return _serviceResult;
        }

        public ServiceResult GetByProperty(string name, string value)
        {
            _serviceResult.MoreInfo = Properties.Resource.GET;
            try
            {
                var entity = _baseRepository.GetByProperty(name, value);
                _serviceResult.SetSuccess(_serviceResult, entity);
                if (entity != null)
                {
                    _serviceResult.UserMessage = $"Giá trị {value} đã tồn tại";
                    _serviceResult.DevMessage.Add($"Giá trị {value} đã tồn tại");
                }
                else
                {
                    _serviceResult.UserMessage = $"Giá trị {value} chưa có trong csdl";
                    _serviceResult.DevMessage.Add($"Giá trị {value} chưa có trong csdl");
                }

            }
            catch (Exception ex)
            {
                _serviceResult.SetInternalServerError(_serviceResult);
                _serviceResult.DevMessage.Add($"Exception: {ex.Message}");
            }
            return _serviceResult;
        }
    }
}
