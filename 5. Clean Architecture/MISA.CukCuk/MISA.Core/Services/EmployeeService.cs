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
        IEmployeeRepository _employeeRepository;
        ServiceResult _serviceResult;
        public EmployeeService(IEmployeeRepository employeeRepository, IBaseRepository<Employee> baseRepository) : base(baseRepository)
        {
            _serviceResult = new ServiceResult();
            _employeeRepository = employeeRepository;
        }
        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        /// CreatedBy: LNT (17/08)
        //public ServiceResult Add(Employee employee)
        //{
        //    // Xử lý nghiệp vụ
        //    // Kiểm tra thông tin của nhân viên đã hợp lệ chưa?
        //    // 1. Mã nhân viên bắt buộc phải có
        //    if (employee.EmployeeCode == "" || employee.EmployeeCode == null)
        //    {
        //        var errorObj = new
        //        {
        //            devMsg = "Dữ liệu không hợp lệ",
        //            userMeg = "Mã nhân viên không để trống",
        //            errorCode = "misa-002",
        //            moreInfo = "",
        //            traceId = ""
        //        };
        //        _serviceResult.IsValid = false;
        //        _serviceResult.Data = errorObj;
        //        return _serviceResult;
        //    }
        //    // 2. Email đúng định dạng
        //    if (employee.Email == "" || employee.Email == null)
        //    {
        //        var errorObj = new
        //        {
        //            devMsg = "Dữ liệu đầu vào chưa đúng",
        //            userMeg = "Email không được để trống",
        //            errorCode = "misa-003",
        //            moreInfo = "",
        //            traceId = ""
        //        };
        //        _serviceResult.IsValid = false;
        //        _serviceResult.Data = errorObj;
        //        return _serviceResult;
        //    }
        //    else
        //    {
        //        var checkEmail = Regex.IsMatch(employee.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        //        if (checkEmail == false)
        //        {
        //            var errorObj = new
        //            {
        //                devMsg = "Dữ liệu đầu vào chưa đúng",
        //                userMeg = "Email chưa đúng định dạng",
        //                errorCode = "misa-004",
        //                moreInfo = "",
        //                traceId = ""
        //            };
        //            _serviceResult.IsValid = false;
        //            _serviceResult.Data = errorObj;
        //            return _serviceResult;
        //        }
        //    }
        //    //// 3. Check trùng mã nhân viên khi thêm
        //    //try
        //    //{
        //    //    var connectionString = "Host = 47.241.69.179;" +
        //    //                            "Database = MISA.CukCuk_Demo_NVMANH;" +
        //    //                            "User Name = dev;" +
        //    //                            "Password = 12345678";

        //    //    IDbConnection dbConnection = new MySqlConnection(connectionString);


        //    //    var sqlCommand = $"SELECT * FROM Employee WHERE EmployeeCode = @EmployeeCodeParam";
        //    //    DynamicParameters dynamicParam = new DynamicParameters();
        //    //    dynamicParam.Add("@EmployeeCodeParam", employee.EmployeeCode);
        //    //    var rowFind = dbConnection.Execute(sqlCommand, param: dynamicParam);

        //    //    if (rowFind != null)
        //    //    {
        //    //        var errorObj = new
        //    //        {
        //    //            devMsg = "Dữ liệu đầu vào chưa đúng",
        //    //            userMeg = "Mã nhân viên bị trùng",
        //    //            errorCode = "misa-004",
        //    //            moreInfo = rowFind,
        //    //            traceId = ""
        //    //        };
        //    //        _serviceResult.IsValid = false;
        //    //        _serviceResult.Data = errorObj;
        //    //        return _serviceResult;
        //    //    }

        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    var errorObj = new
        //    //    {
        //    //        devMsg = ex.Message,
        //    //        userMeg = "Có lỗi, vui lòng liên hệ MISA!",
        //    //        errorCode = "misa-001",
        //    //        moreInfo = "",
        //    //        traceId = ""
        //    //    };
        //    //    _serviceResult.IsValid = false;
        //    //    _serviceResult.Data = errorObj;
        //    //    return _serviceResult;
        //    //}
        //    // Tương tác kết nối DB (Phần việc của Repos => Chuyển cho Repos)
        //    _serviceResult.Data = _employeeRepository.Add(employee);
        //    return _serviceResult;
        //}
        /// <summary>
        /// Xóa thông tin 1 khách hàng theo ID
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        /// CreatedBy: LNT (17/08)
        //public ServiceResult Delete(Guid employeeId)
        //{
        //    _serviceResult.Data = _employeeRepository.Delete(employeeId);
        //    return _serviceResult;
        //}
        /// <summary>
        /// Lấy danh sách toàn bộ khách hàng
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: LNT (17/08)
        /// 
        //public ServiceResult Get()
        //{
        //    _serviceResult.Data = _employeeRepository.Get();
        //    return _serviceResult;
        //}

        /// <summary>
        /// Lấy thông tin 1 khách hàng theo ID
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        /// CreatedBy: LNT (17/08)
        //public ServiceResult GetById(Guid employeeId)
        //{
        //    _serviceResult.Data = _employeeRepository.GetById(employeeId);
        //    return _serviceResult;
        //}
        /// <summary>
        /// Cập nhật thông tin khách hàng theo ID
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        /// CreatedBy: LNT (17/08)
        //public ServiceResult Update(Employee employee, Guid employeeId)
        //{
        //    // Xử lý nghiệp vụ
        //    // Kiểm tra thông tin của nhân viên đã hợp lệ chưa?
        //    // 1. Mã nhân viên bắt buộc phải có
        //    if (employee.EmployeeCode == "" || employee.EmployeeCode == null)
        //    {
        //        var errorObj = new
        //        {
        //            devMsg = "Dữ liệu không hợp lệ",
        //            userMeg = "Mã nhân viên không để trống",
        //            errorCode = "misa-002",
        //            moreInfo = "",
        //            traceId = ""
        //        };
        //        _serviceResult.IsValid = false;
        //        _serviceResult.Data = errorObj;
        //        return _serviceResult;
        //    }
        //    // 2. Email đúng định dạng
        //    if (employee.Email == "" || employee.Email == null)
        //    {
        //        var errorObj = new
        //        {
        //            devMsg = "Dữ liệu đầu vào chưa đúng",
        //            userMeg = "Email không được để trống",
        //            errorCode = "misa-003",
        //            moreInfo = "",
        //            traceId = ""
        //        };
        //        _serviceResult.IsValid = false;
        //        _serviceResult.Data = errorObj;
        //        return _serviceResult;
        //    }
        //    else
        //    {
        //        var checkEmail = Regex.IsMatch(employee.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        //        if (checkEmail == false)
        //        {
        //            var errorObj = new
        //            {
        //                devMsg = "Dữ liệu đầu vào chưa đúng",
        //                userMeg = "Email chưa đúng định dạng",
        //                errorCode = "misa-004",
        //                moreInfo = "",
        //                traceId = ""
        //            };
        //            _serviceResult.IsValid = false;
        //            _serviceResult.Data = errorObj;
        //            return _serviceResult;
        //        }
        //    }
        //    /*
        //    // 3. Check trùng mã nhân viên khi thêm
        //    try
        //    {
        //        var connectionString = "Host = 47.241.69.179;" +
        //                                "Database = MISA.CukCuk_Demo_NVMANH;" +
        //                                "User Name = dev;" +
        //                                "Password = 12345678";

        //        IDbConnection dbConnection = new MySqlConnection(connectionString);


        //        var sqlCommand = $"SELECT * FROM Employee WHERE EmployeeCode = @EmployeeCodeParam";
        //        DynamicParameters dynamicParam = new DynamicParameters();
        //        dynamicParam.Add("@EmployeeCodeParam", employee.EmployeeCode);
        //        var rowFind = dbConnection.Execute(sqlCommand, param: dynamicParam);

        //        if (rowFind != null)
        //        {
        //            var errorObj = new
        //            {
        //                devMsg = "Dữ liệu đầu vào chưa đúng",
        //                userMeg = "Mã nhân viên bị trùng",
        //                errorCode = "misa-004",
        //                moreInfo = rowFind,
        //                traceId = ""
        //            };
        //            _serviceResult.IsValid = false;
        //            _serviceResult.Data = errorObj;
        //            return _serviceResult;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        var errorObj = new
        //        {
        //            devMsg = ex.Message,
        //            userMeg = "Có lỗi, vui lòng liên hệ MISA!",
        //            errorCode = "misa-001",
        //            moreInfo = "",
        //            traceId = ""
        //        };
        //        _serviceResult.IsValid = false;
        //        _serviceResult.Data = errorObj;
        //        return _serviceResult;
        //    }
        //    */
        //    // Tương tác kết nối DB (Phần việc của Repos => Chuyển cho Repos)
        //    _serviceResult.Data = _employeeRepository.Update(employee, employeeId);
        //    return _serviceResult;
        //}
        //public ServiceResult GetNewEmployeeCode()
        //{
        //    //ServiceResult serviceResult = new ServiceResult();
        //    _serviceResult.MoreInfo = Properties.Resource.GET;
        //    try
        //    {
        //        var employee = _employeeRepository.GetNewEmployeeCode();
        //        if (employee != null)
        //        {
        //            _serviceResult.SetSuccess(_serviceResult, employee);
        //        }
        //        else
        //        {
        //            _serviceResult.SetNoContent(_serviceResult);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _serviceResult.SetInternalServerError(_serviceResult);
        //        _serviceResult.DevMessage.Add($"Exception: {ex.Message}");
        //    }
        //    return _serviceResult;
        //}

        public ServiceResult GetEmployeeByProperty(string name, string value)
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
