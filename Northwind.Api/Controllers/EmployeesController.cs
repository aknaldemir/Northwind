using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Dal.Abstract;


namespace Northwind.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeDal _employeeDal;

        public EmployeesController(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        [HttpGet("getemployeebyid/{id:int}")]
        public IActionResult GetEmployeeById(int id)
        {
            var result=_employeeDal.GetEmployeeById(id);
            return Ok(result);
        }

        [HttpGet("getemployees")]
        public IActionResult GetEmployees()
        {
            var result=_employeeDal.GetEmployees();
            return Ok(result);
        }


    }
}
