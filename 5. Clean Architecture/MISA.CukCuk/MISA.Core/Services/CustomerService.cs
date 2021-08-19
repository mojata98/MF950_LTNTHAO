using Dapper;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

namespace MISA.Core.Services
{
    public class CustomerService : ICustomerService
    {
        ICustomerRepository _customerRepository;
        ServiceResult _serviceResult;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _serviceResult = new ServiceResult();
            _customerRepository = customerRepository;
        }
        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="customer">Thông tin khách hàng</param>
        /// <returns>Kết quả xử lý nghiệp vụ</returns>
        /// CreatedBy: LNT (15/08)
        public ServiceResult Add(Customer customer)
        {
            // Xử lý nghiệp vụ
            // Kiểm tra thông tin của khách hàng đã hợp lệ chưa?
            // 1. Mã khách hàng bắt buộc phải có
            if (customer.CustomerCode == "" || customer.CustomerCode == null)
            {
                var errorObj = new
                {
                    devMsg = "Dữ liệu không hợp lệ",
                    userMeg = "Mã khách hàng không để trống",
                    errorCode = "misa-002",
                    moreInfo = "",
                    traceId = ""
                };
                _serviceResult.IsValid = false;
                _serviceResult.Data = errorObj;
                return _serviceResult;
            }
            // 2. Email đúng định dạng
            if (customer.Email == "" || customer.Email == null)
            {
                var errorObj = new
                {
                    devMsg = "Dữ liệu đầu vào chưa đúng",
                    userMeg = "Email không được để trống",
                    errorCode = "misa-003",
                    moreInfo = "",
                    traceId = ""
                };
                _serviceResult.IsValid = false;
                _serviceResult.Data = errorObj;
                return _serviceResult;
            }
            else
            {
                var checkEmail = Regex.IsMatch(customer.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
                if (checkEmail == false)
                {
                    var errorObj = new
                    {
                        devMsg = "Dữ liệu đầu vào chưa đúng",
                        userMeg = "Email chưa đúng định dạng",
                        errorCode = "misa-004",
                        moreInfo = "",
                        traceId = ""
                    };
                    _serviceResult.IsValid = false;
                    _serviceResult.Data = errorObj;
                    return _serviceResult;
                }
            }
            // 3. Check trùng mã nhân viên khi thêm
            //try
            //{
            //    var connectionString = "Host = 47.241.69.179;" +
            //                            "Database = MISA.CukCuk_Demo_NVMANH;" +
            //                            "User Name = dev;" +
            //                            "Password = 12345678";

            //    IDbConnection dbConnection = new MySqlConnection(connectionString);

                
            //    var sqlCommand = $"SELECT * FROM Customer WHERE CustomerCode = @CustomerCodeParam";
            //    DynamicParameters dynamicParam = new DynamicParameters();
            //    dynamicParam.Add("@CustomerCodeParam", customer.CustomerCode);
            //    var rowFind = dbConnection.Execute(sqlCommand, param:dynamicParam);

            //    if (rowFind != null)
            //    {
            //        var errorObj = new
            //        {
            //            devMsg = "Dữ liệu đầu vào chưa đúng",
            //            userMeg = "Mã khách hàng bị trùng",
            //            errorCode = "misa-004",
            //            moreInfo = rowFind,
            //            traceId = ""
            //        };
            //        _serviceResult.IsValid = false;
            //        _serviceResult.Data = errorObj;
            //        return _serviceResult;
            //    }
                
            //}
            //catch (Exception ex)
            //{
            //    var errorObj = new
            //    {
            //        devMsg = ex.Message,
            //        userMeg = "Có lỗi, vui lòng liên hệ MISA!",
            //        errorCode = "misa-001",
            //        moreInfo = "",
            //        traceId = ""
            //    };
            //    _serviceResult.IsValid = false;
            //    _serviceResult.Data = errorObj;
            //    return _serviceResult;
            //}
            // Tương tác kết nối DB (Phần việc của Repos => Chuyển cho Repos)
            _serviceResult.Data = _customerRepository.Add(customer);
            return _serviceResult;
        }
        /// <summary>
        /// Cập nhật thông tin khách hàng
        /// </summary>
        /// <param name="customer">Thông tin khách hàng</param>
        /// <returns>Kết quả xử lý nghiệp vụ</returns>
        /// CreatedBy: LNT (15/08)
        public ServiceResult Update(Customer customer, Guid customerId)
        {

            // Xử lý nghiệp vụ
            // Kiểm tra thông tin của khách hàng đã hợp lệ chưa?
            // 1. Mã khách hàng bắt buộc phải có
            if (customer.CustomerCode == "" || customer.CustomerCode == null)
            {
                var errorObj = new
                {
                    devMsg = "Dữ liệu không hợp lệ",
                    userMeg = "Mã khách hàng không để trống",
                    errorCode = "misa-002",
                    moreInfo = "",
                    traceId = ""
                };
                _serviceResult.IsValid = false;
                _serviceResult.Data = errorObj;
                return _serviceResult;
            }
            // 2. Email đúng định dạng
            if (customer.Email == "" || customer.Email == null)
            {
                var errorObj = new
                {
                    devMsg = "Dữ liệu đầu vào chưa đúng",
                    userMeg = "Email không được để trống",
                    errorCode = "misa-003",
                    moreInfo = "",
                    traceId = ""
                };
                _serviceResult.IsValid = false;
                _serviceResult.Data = errorObj;
                return _serviceResult;
            }
            else
            {
                var checkEmail = Regex.IsMatch(customer.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
                if (checkEmail == false)
                {
                    var errorObj = new
                    {
                        devMsg = "Dữ liệu đầu vào chưa đúng",
                        userMeg = "Email chưa đúng định dạng",
                        errorCode = "misa-004",
                        moreInfo = "",
                        traceId = ""
                    };
                    _serviceResult.IsValid = false;
                    _serviceResult.Data = errorObj;
                    return _serviceResult;
                }
            }
            /*
            // 3. Check trùng mã nhân viên khi thêm
            try
            {
                var connectionString = "Host = 47.241.69.179;" +
                                        "Database = MISA.CukCuk_Demo_NVMANH;" +
                                        "User Name = dev;" +
                                        "Password = 12345678";

                IDbConnection dbConnection = new MySqlConnection(connectionString);


                var sqlCommand = $"SELECT * FROM Customer WHERE CustomerCode = @CustomerCodeParam";
                DynamicParameters dynamicParam = new DynamicParameters();
                dynamicParam.Add("@CustomerCodeParam", customer.CustomerCode);
                var rowFind = dbConnection.Execute(sqlCommand, param: dynamicParam);

                if (rowFind != null)
                {
                    var errorObj = new
                    {
                        devMsg = "Dữ liệu đầu vào chưa đúng",
                        userMeg = "Mã khách hàng bị trùng",
                        errorCode = "misa-004",
                        moreInfo = rowFind,
                        traceId = ""
                    };
                    _serviceResult.IsValid = false;
                    _serviceResult.Data = errorObj;
                    return _serviceResult;
                }

            }
            catch (Exception ex)
            {
                var errorObj = new
                {
                    devMsg = ex.Message,
                    userMeg = "Có lỗi, vui lòng liên hệ MISA!",
                    errorCode = "misa-001",
                    moreInfo = "",
                    traceId = ""
                };
                _serviceResult.IsValid = false;
                _serviceResult.Data = errorObj;
                return _serviceResult;
            }
            */
            // Tương tác kết nối DB (Phần việc của Repos => Chuyển cho Repos)
            _serviceResult.Data = _customerRepository.Update(customer, customerId);
            return _serviceResult;
        }
        /// <summary>
        /// Lấy thông tin tất cả khách hàng
        /// </summary>
        /// <returns>Kết quả xử lý nghiệp vụ</returns>
        /// CreatedBy: LNT (15/08)
        public ServiceResult Get()
        {
            _serviceResult.Data = _customerRepository.Get();
            return _serviceResult;
        }
        /// <summary>
        /// Lấy thông tin khách hàng theo Id
        /// </summary>
        /// <param name="customerId">Id khách hàng</param>
        /// <returns>Kết quả xử lý nghiệp vụ</returns>
        /// CreatedBy: LNT (15/08)
        public ServiceResult GetById(Guid customerId)
        {
            _serviceResult.Data = _customerRepository.GetById(customerId);
            return _serviceResult;
        }
        /// <summary>
        /// Xóa thông tin khách hàng
        /// </summary>
        /// <param name="customerId">Id khách hàng</param>
        /// <returns>Kết quả xử lý nghiệp vụ</returns>
        /// CreatedBy: LNT (15/08)
        public ServiceResult Delete(Guid customerId)
        {
            _serviceResult.Data = _customerRepository.Delete(customerId);
            return _serviceResult;
        }
    }
}
