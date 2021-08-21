using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MySqlConnector;
using Dapper;
using System.Text.RegularExpressions;
using MISA.Core.Interfaces.Services;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using System.IO;
using System.Threading;
using OfficeOpenXml;

namespace MISA.CukCuk.Api.DEMO.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
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
                // 4. Trả về cho client
                var serviceResult = _customerService.Get();

                if (serviceResult.IsValid == true)
                {
                    return StatusCode(201, serviceResult.Data);
                }
                else
                {
                    return BadRequest(serviceResult.Data);
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
        /// Lấy dữ lệu 1 bản ghi theo id
        /// </summary>
        /// <param name="customerId">Id của khách hàng</param>
        /// <returns></returns>
        [HttpGet("{customerId}")]
        public IActionResult GetById(Guid customerId)
        {
            try
            {
                // 4. Trả về cho client
                var serviceResult = _customerService.GetById(customerId);

                if (serviceResult.IsValid == true)
                {
                    return StatusCode(201, serviceResult.Data);
                }
                else
                {
                    return BadRequest(serviceResult.Data);
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
                var serviceResult = _customerService.Add(customer);
                
                if (serviceResult.IsValid == true)
                {
                    return StatusCode(201, serviceResult.Data);
                }
                else
                {
                    return BadRequest(serviceResult.Data);
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
                // 4. Trả về cho client
                var serviceResult = _customerService.Delete(customerId);

                if (serviceResult.IsValid == true)
                {
                    return StatusCode(201, serviceResult.Data);
                }
                else
                {
                    return BadRequest(serviceResult.Data);
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
                var serviceResult = _customerService.Update(customer, customerId);
                if (serviceResult.IsValid == true)
                {
                    return StatusCode(201, serviceResult.Data);
                }
                else
                {
                    return BadRequest(serviceResult.Data);
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
        /// Import file excel
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("Import")]
        public IActionResult Import(IFormFile formFile)
        {
            try
            {
                var serviceResult = _customerService.Import(formFile);
                if (serviceResult.IsValid == true)
                {
                    return StatusCode(201, serviceResult.Data);
                }
                else
                {
                    return BadRequest(serviceResult.Data);
                }

                //var res = _customerService.Import(formFile);
                //if (res.ErrorCode == MISACode.NoValid)
                //{
                //    res.Status = RequestStatus.Fail;
                //    return StatusCode(400, res);
                //}
                //else if (res.Status == RequestStatus.Fail)
                //{
                //    return StatusCode(204, res);
                //}
                //else
                //{
                //    return StatusCode(200, res.Data);
                //}
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
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("InsertFromFile")]
        public IActionResult InsertFromFile()
        {
            try
            {
                var serviceResult = _customerService.InsertCustomersFromFile();
                if (serviceResult.IsValid == true)
                {
                    return StatusCode(201, serviceResult.Data);
                }
                else
                {
                    return BadRequest(serviceResult.Data);
                }

                var result = _customerService.InsertCustomersFromFile();
                //if (result.Count == 0)
                //{
                //    _serviceResult.Status = RequestStatus.Fail;
                //    return StatusCode(204, result);
                //}
                //else
                //{
                //    _serviceResult.Status = RequestStatus.Complete;
                //    return StatusCode(200, result);
                //}
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
