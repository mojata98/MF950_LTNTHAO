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

namespace MISA.CukCuk.Api.DEMO.Controllers
{
    [Route("api/[controller]")]
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
        /// <summary>
        /// Lấy dữ lệu 1 bản ghi theo id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet("{customerId}")]
        public IActionResult GetById(Guid customerId)
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

            var response = StatusCode(200, customers);
            return response;
        }
        /// <summary>
        /// Thêm 1 bản ghi
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertCustomer(Customer customer)
        {
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

            var response = StatusCode(200, rowEffects);
            return response;
        }
        /// <summary>
        /// Xóa 1 bản ghi theo id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpDelete("{customerId}")]
        public IActionResult DeleteById(Guid customerId)
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

            var response = StatusCode(200, customers);
            return response;
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

            var response = StatusCode(200, rowEffects);
            return response;
        }
    }
}
