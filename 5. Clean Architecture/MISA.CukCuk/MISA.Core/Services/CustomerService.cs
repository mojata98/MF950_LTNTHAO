using Dapper;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using MySqlConnector;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

        /// <summary>
        /// Import du lieu
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        public ServiceResult Import(IFormFile formFile)
        {
            var customers = new List<Customer>();
            //Kieu tra co hop le hay ko
            if (formFile == null)
            {
                var msgError = new
                {
                    devMsg = "File gửi lên không được rỗng",
                    userMsg = "File gửi lên không được rỗng",
                };
                _serviceResult.Data = msgError;
                //_serviceResult.Status = RequestStatus.Fail;
                //_serviceResult.ErrorCode = MISACode.NoValid;
                return _serviceResult;
            }
            var listCode = new List<string>();
            var listPhone = new List<string>();
            //Doc du lieu trong file excel
            using (var stream = new MemoryStream())
            {
                formFile.CopyToAsync(stream);

                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;

                    for (int row = 3; row <= rowCount; row++)
                    {
                        var phone = worksheet.Cells[row, 5].Value == null ? null : worksheet.Cells[row, 5].Value.ToString().Replace(".", "").Replace(" ", "");

                        var customer = new Customer
                        {
                            CustomerCode = worksheet.Cells[row, 1].Value == null ? null : worksheet.Cells[row, 1].Value.ToString().Trim(),
                            FullName = worksheet.Cells[row, 2].Value == null ? null : worksheet.Cells[row, 2].Value.ToString().Trim(),
                            MemberCardCode = worksheet.Cells[row, 3].Value == null ? null : worksheet.Cells[row, 3].Value.ToString().Trim(),
                            CustomerGroupName = worksheet.Cells[row, 4].Value == null ? null : worksheet.Cells[row, 4].Value.ToString().Trim(),
                            CustomerGroupId = GetCustomerGroupId(worksheet.Cells[row, 4].Value == null ? null : worksheet.Cells[row, 4].Value.ToString().Trim()),
                            PhoneNumber = phone,
                            DateOfBirth = FormatDob(worksheet.Cells[row, 6].Value == null ? null : worksheet.Cells[row, 6].Value.ToString().Trim()),
                            CompanyName = worksheet.Cells[row, 7].Value == null ? null : worksheet.Cells[row, 7].Value.ToString().Trim(),
                            CompanyTaxCode = worksheet.Cells[row, 8].Value == null ? null : worksheet.Cells[row, 8].Value.ToString().Trim(),
                            Email = worksheet.Cells[row, 9].Value == null ? null : worksheet.Cells[row, 9].Value.ToString().Trim(),
                            Address = worksheet.Cells[row, 10].Value == null ? null : worksheet.Cells[row, 10].Value.ToString().Trim(),
                            ImportError = new List<string>()
                        };

                        if (listCode.Contains(customer.CustomerCode))
                        {
                            var msg = $"Mã khách hàng {customer.CustomerCode} đã trùng với khách hàng khác trong tệp nhập khẩu.";
                            customer.ImportError.Add(msg);
                        }
                        if (listPhone.Contains(customer.PhoneNumber))
                        {
                            customer.ImportError.Add($"Số điện thoại {customer.PhoneNumber} đã trùng với khách hàng khác trong tệp nhập khẩu.");
                        }
                        listCode.Add(customer.CustomerCode);
                        listPhone.Add(customer.PhoneNumber);
                        customers.Add(customer);

                    }
                }
            }

            if (customers.Count() == 0)
            {
                _serviceResult.Status = RequestStatus.Fail;
            }
            else
            {
                ValidateDataFile(customers);
                _customersList.AddRange(customers);
                _serviceResult.ErrorCode = MISACode.IsValid;
                _serviceResult.Status = RequestStatus.Complete;
            }
            _serviceResult.Data = customers;
            return _serviceResult;
        }


        public List<int> InsertCustomersFromFile()
        {
            try
            {
                var list = new List<int>();
                var cout = _customersList.Count();
                var res = _customerRepository.InsertCustomers(_customersList);
                list.Add(res);
                list.Add(cout);
                return list;
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// Format date
        /// </summary>
        /// <param name="dob"></param>
        /// <returns>Datetime format đúng</returns>
        ///  CreateBY: TTUYEN(20/08/2021)
        private DateTime? FormatDob(string dob)
        {
            try
            {
                string[] formats = { "dd/MM/yyyy", "MM/yyyy", "yyyy" };
                if (dob == null)
                {
                    return null;
                }
                else
                {
                    var result = DateTime.ParseExact(dob, formats, provider: null);
                    return result;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Trả về id group theo tên
        /// </summary>
        /// <param name="customerGroupId"></param>
        /// <returns>CustomerGroupId</returns>
        ///  CreateBY: TTUYEN(20/08/2021)
        public Guid? GetCustomerGroupId(string customerGroupName)
        {
            try
            {
                var res = _customerRepository.GetCustomerGroupId(customerGroupName);
                if (res.Equals(Guid.Empty))
                {
                    return null;
                }
                return res;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Validate dữ liệu trong file
        /// </summary>
        /// <param name="customers"></param>
        /// CreateBY: TTUYEN(20/08/2021)
        private void ValidateDataFile(List<Customer> customers)
        {
            foreach (Customer customer in customers)
            {
                if (customer.CustomerGroupId == null)
                {
                    customer.ImportError.Add("Nhóm khách hàng không có trong hệ thống");

                }
                if (customer.CustomerCode == null)
                {
                    var msg = "Mã khách hàng không được phép để trống";
                    customer.ImportError.Add(msg);
                }
                else
                {
                    var isExistCode = _customerRepository.GetCustomerCodeExist(customer.CustomerCode);
                    if (!isExistCode)
                    {
                        customer.ImportError.Add($"Mã khách hàng {customer.CustomerCode} đã tồn tại trong hệ thống");
                    }
                }
                if (string.IsNullOrEmpty(customer.Email))
                {
                    customer.ImportError.Add("Email khách hàng không được để trống");
                }
                if (string.IsNullOrEmpty(customer.PhoneNumber))
                {
                    customer.ImportError.Add("Số điện thoại khách hàng không được để trống");
                }
                else
                {
                    var isExist = _customerRepository.GetCustomerPhoneNumberExist(customer.PhoneNumber);
                    if (!isExist)
                    {
                        customer.ImportError.Add($"Số điện thoại {customer.PhoneNumber} đã tồn tại trong hệ thống");
                    }
                }
            }
        }

    }
}
