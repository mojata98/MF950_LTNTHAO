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

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //var employees = _employeeRepository.Get();
                //return Ok(employees);
                var serviceResult = _employeeService.Get();

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

        [HttpGet("{employeeId}")]
        public IActionResult GetById(Guid employeeId)
        {
            try
            {
                // 4. Trả về cho client
                var serviceResult = _employeeService.GetById(employeeId);

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
            //return Ok();
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            try
            {
                var serviceResult = _employeeService.Add(employee);

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

        [HttpPut("{employeeId}")]
        public IActionResult Update(Employee employee,Guid employeeId)
        {
            try
            {
                var serviceResult = _employeeService.Update(employee, employeeId);
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

        [HttpDelete("{employeeId}")]
        public IActionResult Delete(Guid employeeId)
        {
            try
            {
                // 4. Trả về cho client
                var serviceResult = _employeeService.Delete(employeeId);

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
            //return Ok();
        }
    }
}
