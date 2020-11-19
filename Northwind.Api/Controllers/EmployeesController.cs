using Microsoft.AspNetCore.Mvc;
using Northwind.Dal.Abstract;


namespace Northwind.Api.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeDal _employeeDal;
        public EmployeesController(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        [HttpGet("employees/{id:int}")]
        public IActionResult GetEmployeeById(int id)
        {
            var result=_employeeDal.GetEmployeeById(id);
            return Ok(result);
        }


        
        [HttpGet("employees")]
        public IActionResult GetEmployees()
        {
            var employees=_employeeDal.GetEmployees();
            return Ok(employees);
        }
    }
}
