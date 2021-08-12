using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.CukCuk.Api.DEMO.Model;
using System.Data;
using MySqlConnector;
using Dapper;
using System.Text.RegularExpressions;

namespace MISA.CukCuk.Api.DEMO.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // Xác định phương thức: GET, POST, PUT, DELETE

        // Viết phương thức

        /// <summary>
        /// Lấy dữ liệu toàn bộ bảng
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCustomers()
        {
            try
            {
                // Truy cập vào database
                // 1. Khai báo thông tin database
                var connectionString = "Host = 47.241.69.179;" +
                                        "Database = MISA.CukCuk_Demo_NVMANH;" +
                                        "User Name = dev;" +
                                        "Password = 12345678";

                // 2. Khởi tạo đối tượng kết nối database
                IDbConnection dbConnection = new MySqlConnection(connectionString);

                // 3. Lấy dữ liệu
                var sqlCommand = "SELECT * FROM Customer";
                var customers = dbConnection.Query<Customer>(sqlCommand);
                // 4. Trả về cho client

                var response = StatusCode(200, customers);
                return response;
            }
            catch (Exception ex)
            {
                var errorObj = new
                {
                    devMsg = ex.Message,
                    userMeg = Properties.Resources.Exception_ErrorMsg,
                    errorCode = "misa-001",
                    moreInfo = "",
                    traceId = ""
                };
                return StatusCode(500, errorObj);
            }
            
        }
        /// <summary>
        /// Lấy dữ lệu 1 bản ghi theo id
        /// </summary>
        /// <param name="customerId">Id của khách hàng</param>
        /// <returns></returns>
        [HttpGet("{customerId}")]
        public IActionResult GetById(Guid customerId)
        {
            try
            {
                var connectionString = "Host = 47.241.69.179;" +
                                    "Database = MISA.CukCuk_Demo_NVMANH;" +
                                    "User Name = dev;" +
                                    "Password = 12345678";

                IDbConnection dbConnection = new MySqlConnection(connectionString);

                var sqlCommand = $"SELECT * FROM Customer WHERE CustomerId = @CustomerIdParam"; // C1: '{customerId.ToString()}'
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CustomerIdParam", customerId);
                var customers = dbConnection.QueryFirstOrDefault<Customer>(sqlCommand, param: parameters); // Lấy bản ghi đầu tiên

                if (customers != null)
                {
                    var resultObj = new
                    {
                        message = Properties.ResourceResponseSuccess.Get_Data_Success,
                    };
                    return StatusCode(200, customers);
                }
                else
                {
                    var resultObj = new
                    {
                        message = Properties.Resources.Get_Data_Fail,
                    };
                    return StatusCode(204, resultObj);
                }
                
            }
            catch (Exception ex)
            {
                var errorObj = new
                {
                    devMsg = ex.Message,
                    userMeg = Properties.Resources.Exception_ErrorMsg,
                    errorCode = "misa-001",
                    moreInfo = "",
                    traceId = ""
                };
                return StatusCode(500, errorObj);
            }
            
        }
        /// <summary>
        /// Thêm 1 bản ghi
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertCustomer(Customer customer)
        {
            try
            {
                // Kiểm tra thông tin của khách hàng đã hợp lệ chưa?
                // 1. Mã khách hàng bắt buộc phải có
                if (customer.CustomerCode == "" || customer.CustomerCode == null)
                {
                    var errorObj = new
                    {
                        devMsg = Properties.ResourceDev.Exception_Invalid_Input,
                        userMeg = Properties.Resources.Exception_NullEmployeeCode,
                        errorCode = "misa-002",
                        moreInfo = "",
                        traceId = ""
                    };
                    return BadRequest(errorObj);
                }
                // 2. Email đúng định dạng
                if (customer.Email == "" || customer.Email == null)
                {
                    var errorObj = new
                    {
                        devMsg = Properties.ResourceDev.Exception_Invalid_Input,
                        userMeg = Properties.Resources.Exception_Email_Null,
                        errorCode = "misa-003",
                        moreInfo = "",
                        traceId = ""
                    };
                    return BadRequest(errorObj);
                }
                else
                {
                    var checkEmail = Regex.IsMatch(customer.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
                    if (checkEmail == false)
                    {
                        var errorObj = new
                        {
                            devMsg = Properties.ResourceDev.Exception_Invalid_Input,
                            userMeg = Properties.Resources.Exception_Email_Invalid,
                            errorCode = "misa-004",
                            moreInfo = "",
                            traceId = ""
                        };
                        return BadRequest(errorObj);
                    }
                }
                customer.CustomerId = Guid.NewGuid();
                var connectionString = "Host = 47.241.69.179;" +
                                        "Database = MISA.CukCuk_Demo_NVMANH;" +
                                        "User Name = dev;" +
                                        "Password = 12345678";

                IDbConnection dbConnection = new MySqlConnection(connectionString);


                // Thêm dữ liệu vào db
                var columnsName = string.Empty;
                var columnsParam = string.Empty;
                // Khai báo dynamicParam 
                var dynamicParam = new DynamicParameters();
                // Đọc từng property của object
                var properties = customer.GetType().GetProperties();

                // Duyệt từng property
                foreach (var prop in properties)
                {
                    // Lấy tên của prop
                    var propName = prop.Name;

                    // Lấy value của prop
                    var propValue = prop.GetValue(customer);

                    // Lấy kiểu dữ liệu của prop
                    var propType = prop.PropertyType;

                    // Thêm param tương ứng với mỗi property của đối tượng
                    dynamicParam.Add($"@{propName}", propValue);

                    columnsName += $"{propName},";
                    columnsParam += $"@{propName},";
                }

                columnsName = columnsName.Remove(columnsName.Length - 1, 1);
                columnsParam = columnsParam.Remove(columnsParam.Length - 1, 1);

                var sqlCommand = $"INSERT INTO Customer({columnsName}) VALUES({columnsParam})";

                var rowEffects = dbConnection.Execute(sqlCommand, param: dynamicParam); // trả số bản ghi thay đổi

                if (rowEffects > 0)
                {
                    var resultObj = new
                    {
                        message = Properties.ResourceResponseSuccess.Number_Row_Updated,
                        row_Updated = rowEffects
                    };
                    return StatusCode(201, resultObj);
                }
                else
                {
                    var resultObj = new
                    {
                        message = Properties.Resources.Exception_Row_NoUpdated,
                        row_Updated = rowEffects
                    };
                    return StatusCode(204, resultObj);
                }
            }
            catch (Exception ex)
            {
                var errorObj = new
                {
                    devMsg = ex.Message,
                    userMeg = Properties.Resources.Exception_ErrorMsg,
                    errorCode = "misa-001",
                    moreInfo = "",
                    traceId = ""
                };
                return StatusCode(500, errorObj);
            }
            
        }
        /// <summary>
        /// Xóa 1 bản ghi theo id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpDelete("{customerId}")]
        public IActionResult DeleteById(Guid customerId)
        {
            try
            {
                var connectionString = "Host = 47.241.69.179;" +
                                    "Database = MISA.CukCuk_Demo_NVMANH;" +
                                    "User Name = dev;" +
                                    "Password = 12345678";

                IDbConnection dbConnection = new MySqlConnection(connectionString);

                var sqlCommand = $"DELETE FROM Customer WHERE CustomerId = @CustomerIdParam"; // C1: '{customerId.ToString()}'
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CustomerIdParam", customerId);
                var customers = dbConnection.QueryFirstOrDefault<Customer>(sqlCommand, param: parameters); // Lấy bản ghi đầu tiên

                if (customers != null)
                {
                    var resultObj = new
                    {
                        message = Properties.ResourceResponseSuccess.Number_Row_Updated,
                    };
                    return StatusCode(200);
                }
                else
                {
                    var resultObj = new
                    {
                        message = Properties.Resources.Exception_Row_NoDeleted,
                    };
                    return StatusCode(204, customers);
                }
            }
            catch (Exception ex)
            {
                var errorObj = new
                {
                    devMsg = ex.Message,
                    userMeg = Properties.Resources.Exception_ErrorMsg,
                    errorCode = "misa-001",
                    moreInfo = "",
                    traceId = ""
                };
                return StatusCode(500, errorObj);
            }
            
        }
        /// <summary>
        /// Sửa thông tin theo id
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut("{customerId}")]
        public IActionResult ChangeInforById(Guid customerId, Customer customer)
        {
            try
            {
                // Kiểm tra thông tin của khách hàng đã hợp lệ chưa?
                // 1. Mã khách hàng bắt buộc phải có
                if (customer.CustomerCode == "" || customer.CustomerCode == null)
                {
                    var errorObj = new
                    {
                        devMsg = Properties.ResourceDev.Exception_Invalid_Input,
                        userMeg = Properties.Resources.Exception_NullEmployeeCode,
                        errorCode = "misa-002",
                        moreInfo = "",
                        traceId = ""
                    };
                    return BadRequest(errorObj);
                }
                // 2. Email đúng định dạng
                if (customer.Email == "" || customer.Email == null)
                {
                    var errorObj = new
                    {
                        devMsg = Properties.ResourceDev.Exception_Invalid_Input,
                        userMeg = Properties.Resources.Exception_Email_Null,
                        errorCode = "misa-003",
                        moreInfo = "",
                        traceId = ""
                    };
                    return BadRequest(errorObj);
                }
                else
                {
                    var checkEmail = Regex.IsMatch(customer.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
                    if (checkEmail == false)
                    {
                        var errorObj = new
                        {
                            devMsg = Properties.ResourceDev.Exception_Invalid_Input,
                            userMeg = Properties.Resources.Exception_Email_Invalid,
                            errorCode = "misa-004",
                            moreInfo = "",
                            traceId = ""
                        };
                        return BadRequest(errorObj);
                    }
                }
                var connectionString = "Host = 47.241.69.179;" +
                                   "Database = MISA.CukCuk_Demo_NVMANH;" +
                                   "User Name = dev;" +
                                   "Password = 12345678";

                IDbConnection dbConnection = new MySqlConnection(connectionString);

                // Thêm dữ liệu vào db
                var columnsName = string.Empty;
                var columnsParam = string.Empty;
                var resultString = string.Empty;
                // Khai báo dynamicParam 
                var dynamicParam = new DynamicParameters();
                // Đọc từng property của object
                var properties = customer.GetType().GetProperties();

                // Duyệt từng property
                foreach (var prop in properties)
                {
                    // Lấy tên của prop
                    var propName = prop.Name;

                    // Lấy value của prop
                    var propValue = prop.GetValue(customer);

                    // Lấy kiểu dữ liệu của prop
                    var propType = prop.PropertyType;

                    // Thêm param tương ứng với mỗi property của đối tượng
                    dynamicParam.Add($"@{propName}", propValue);

                    resultString += $"{propName} = " + $"@{propName},";
                }
                resultString = resultString.Remove(resultString.Length - 1, 1);
                var sqlCommand = $"UPDATE Customer SET {resultString} WHERE CustomerId = '{customerId.ToString()}'";

                var rowEffects = dbConnection.Execute(sqlCommand, param: dynamicParam);
                if (rowEffects > 0)
                {
                    var resultObj = new
                    {
                        message = Properties.ResourceResponseSuccess.Edit_Susscess,
                        row_Updated = rowEffects
                    };
                    return StatusCode(201, resultObj);
                }
                else
                {
                    var resultObj = new
                    {
                        message = Properties.Resources.Exception_Row_NoEdited,
                        row_Updated = rowEffects
                    };
                    return StatusCode(204, resultObj);
                }
                
            }
            catch (Exception ex)
            {
                var errorObj = new
                {
                    devMsg = ex.Message,
                    userMeg = Properties.Resources.Exception_ErrorMsg,
                    errorCode = "misa-001",
                    moreInfo = "",
                    traceId = ""
                };
                return StatusCode(500, errorObj);
            }         
        }
    }
}
