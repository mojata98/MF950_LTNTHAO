using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interfaces.Services
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        //ServiceResult Get();

        //ServiceResult GetById(Guid employeeId);

        //ServiceResult Add(Employee employee);

        //ServiceResult Update(Employee employee, Guid employeeId);

        //ServiceResult Delete(Guid employeeId);
        //public ServiceResult GetNewEmployeeCode();

        public ServiceResult GetEmployeeByProperty(string name, string value);

    }
}
