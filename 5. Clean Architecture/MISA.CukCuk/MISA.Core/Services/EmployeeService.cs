using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using MySqlConnector;
using System.Text.RegularExpressions;
using System.Data;

namespace MISA.Core.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        //IEmployeeRepository _employeeRepository;
        //ServiceResult _serviceResult;
        //public EmployeeService(IEmployeeRepository employeeRepository, IBaseRepository<Employee> baseRepository) : base(baseRepository)
        //{
        //    _serviceResult = new ServiceResult();
        //    _employeeRepository = employeeRepository;
        //}
        
        //public ServiceResult GetEmployeeByProperty(string name, string value)
        //{
        //    _serviceResult.MoreInfo = Properties.Resource.GET;
        //    try
        //    {
        //        var entity = _baseRepository.GetByProperty(name, value);
        //        _serviceResult.SetSuccess(_serviceResult, entity);
        //        if (entity != null)
        //        {
        //            _serviceResult.UserMessage = $"Giá trị {value} đã tồn tại";
        //            _serviceResult.DevMessage.Add($"Giá trị {value} đã tồn tại");
        //        }
        //        else
        //        {
        //            _serviceResult.UserMessage = $"Giá trị {value} chưa có trong csdl";
        //            _serviceResult.DevMessage.Add($"Giá trị {value} chưa có trong csdl");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        _serviceResult.SetInternalServerError(_serviceResult);
        //        _serviceResult.DevMessage.Add($"Exception: {ex.Message}");
        //    }
        //    return _serviceResult;
        //}

        //public ServiceResult GetNewCode()
        //{
        //    ServiceResult serviceResult = new ServiceResult();
        //    serviceResult.MoreInfo = Properties.Resource.GET;
        //    try
        //    {
        //        var employee = _employeeRepository.GetNewCode();
        //        if (employee != null)
        //        {
        //            serviceResult.SetSuccess(serviceResult, employee);
        //        }
        //        else
        //        {
        //            serviceResult.SetNoContent(serviceResult);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        serviceResult.SetInternalServerError(serviceResult);
        //        serviceResult.DevMessage.Add($"Exception: {ex.Message}");
        //    }
        //    return serviceResult;
        //}
    }
}
