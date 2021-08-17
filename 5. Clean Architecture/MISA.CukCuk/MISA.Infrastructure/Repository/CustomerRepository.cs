using Dapper;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace MISA.Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository

    {
        public int Add(Customer customer)
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
            return rowEffects;
        }

        public int Delete(Guid customerId)
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
            return 1; // OK
        }

        public List<Customer> Get()
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
                return (List<Customer>)customers;
            
            
        }

        public Customer GetById(Guid customerId)
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
            return customers;
        }

        public int Update(Customer customer, Guid customerId)
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
            return rowEffects;
        }
    }
}
