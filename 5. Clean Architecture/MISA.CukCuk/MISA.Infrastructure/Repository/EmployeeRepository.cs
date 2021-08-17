using Dapper;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public int Add(Employee employee)
        {
            employee.EmployeeId = Guid.NewGuid();
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
            var properties = employee.GetType().GetProperties();

            // Duyệt từng property
            foreach (var prop in properties)
            {
                // Lấy tên của prop
                var propName = prop.Name;

                // Lấy value của prop
                var propValue = prop.GetValue(employee);

                // Lấy kiểu dữ liệu của prop
                var propType = prop.PropertyType;

                // Thêm param tương ứng với mỗi property của đối tượng
                dynamicParam.Add($"@{propName}", propValue);

                columnsName += $"{propName},";
                columnsParam += $"@{propName},";
            }

            columnsName = columnsName.Remove(columnsName.Length - 1, 1);
            columnsParam = columnsParam.Remove(columnsParam.Length - 1, 1);

            var sqlCommand = $"INSERT INTO Employee({columnsName}) VALUES({columnsParam})";

            var rowEffects = dbConnection.Execute(sqlCommand, param: dynamicParam); // trả số bản ghi thay đổi
            return rowEffects;
        }

        public int Delete(Guid employeeId)
        {
            var connectionString = "Host = 47.241.69.179;" +
                                    "Database = MISA.CukCuk_Demo_NVMANH;" +
                                    "User Name = dev;" +
                                    "Password = 12345678";

            IDbConnection dbConnection = new MySqlConnection(connectionString);

            var sqlCommand = $"DELETE FROM Employee WHERE EmployeeId = @EmployeeIdParam"; // C1: '{customerId.ToString()}'
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@EmployeeIdParam", employeeId);
            var customers = dbConnection.QueryFirstOrDefault<Employee>(sqlCommand, param: parameters); // Lấy bản ghi đầu tiên
            return 1; // OK
        }

        public List<Employee> Get()
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
            var sqlCommand = "SELECT * FROM Employee";
            var employees = dbConnection.Query<Employee>(sqlCommand);
            //return (List<Employee>)employees;
            return employees.ToList();
        }

        public Employee GetById(Guid employeeId)
        {
            var connectionString = "Host = 47.241.69.179;" +
                                    "Database = MISA.CukCuk_Demo_NVMANH;" +
                                    "User Name = dev;" +
                                    "Password = 12345678";

            IDbConnection dbConnection = new MySqlConnection(connectionString);

            var sqlCommand = $"SELECT * FROM Employee WHERE EmployeeId = @EmployeeIdParam"; // C1: '{customerId.ToString()}'
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@EmployeeIdParam", employeeId);
            var employees = dbConnection.QueryFirstOrDefault<Employee>(sqlCommand, param: parameters); // Lấy bản ghi đầu tiên
            return employees;
        }

        public int Update(Employee employee, Guid employeeId)
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
            var properties = employee.GetType().GetProperties();

            // Duyệt từng property
            foreach (var prop in properties)
            {
                // Lấy tên của prop
                var propName = prop.Name;

                // Lấy value của prop
                var propValue = prop.GetValue(employee);

                // Lấy kiểu dữ liệu của prop
                var propType = prop.PropertyType;

                // Thêm param tương ứng với mỗi property của đối tượng
                dynamicParam.Add($"@{propName}", propValue);

                resultString += $"{propName} = " + $"@{propName},";
            }
            resultString = resultString.Remove(resultString.Length - 1, 1);
            var sqlCommand = $"UPDATE Employee SET {resultString} WHERE EmployeeId = '{employeeId.ToString()}'";

            var rowEffects = dbConnection.Execute(sqlCommand, param: dynamicParam);
            return rowEffects;
        }
    }
}
