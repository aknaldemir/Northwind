using Microsoft.AspNetCore.Mvc;
using Northwind.Dal.Abstract;
using Northwind.Entities.Concrete;


namespace Northwind.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeDal _employeeDal;
        public EmployeesController(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        /// <summary>
        /// Return employee by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("employees/{id:int}")]
        public IActionResult Get(int id)
        {
            var result=_employeeDal.GetEmployeeById(id);
            return Ok(result);
        }
        /// <summary>
        /// Return all employees
        /// </summary>
        /// <returns></returns>

        [HttpGet("employees")]
        public IActionResult Get()
        {
            var employees=_employeeDal.GetEmployees();
            return Ok(employees);
        }

        [HttpPost("employees")]
        public IActionResult Post(Employee employee)
        {
            _employeeDal.Add(employee);
            return StatusCode(201);
        }

    }
}
