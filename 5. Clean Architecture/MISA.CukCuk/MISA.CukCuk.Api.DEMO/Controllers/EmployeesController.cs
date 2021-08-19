using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.DEMO.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        IEmployeeRepository _employeeRepository;
        IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService, IEmployeeRepository employeeRepository)
        {
            _employeeService = employeeService;
            _employeeRepository = employeeRepository;
        }
        /// <summary>
        /// Lấy danh sách khách hàng
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: LNT (17/08)
        [HttpGet]
        public IActionResult Get()
        {           
            var employees = _employeeService.Get();
            return Ok(employees);

        }
        /// <summary>
        /// Lấy thông tin 1 khách hàng theo ID
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        /// CreatedBy: LNT (17/08)
        [HttpGet("{employeeId}")]
        public IActionResult GetById(Guid employeeId)
        {
            
            var employee = _employeeService.GetById(employeeId);
            return StatusCode(employee.ResultCode, employee);
        }
        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        /// /// CreatedBy: LNT (17/08)
        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            
            var rowEffects = _employeeService.Add(employee);
            return  StatusCode(rowEffects.ResultCode, rowEffects);//Ok(rowEffects);
        }
        /// <summary>
        /// Cập nhật thông tin khách hàng theo ID
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        /// /// CreatedBy: LNT (17/08)
        [HttpPut("{employeeId}")]
        public IActionResult Update(Employee employee,Guid employeeId)
        {
            
            ServiceResult serviceResult = _employeeService.Update(employee, employeeId);
            return Ok(serviceResult);
        }
        
        /// <summary>
        /// Xóa thông tin 1 khách hàng theo ID
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        /// /// CreatedBy: LNT (17/08)
        [HttpDelete("{employeeId}")]
        public IActionResult Delete(Guid employeeId)
        {
            
            ServiceResult serviceResult = _employeeService.Delete(employeeId);
            return Ok(serviceResult);
        }
    }
}
