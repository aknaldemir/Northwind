using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Northwind.Dal.Abstract;
using Northwind.Dal.Concrete.EntityFramework.Contexts;
using Northwind.Entities.Concrete;

namespace Northwind.Dal.Concrete.EntityFramework
{
    public class EfEmployeeDal:IEmployeeDal
    {
        private readonly NorthwindContext _context;

        public EfEmployeeDal(NorthwindContext context) 
        {
            _context = context;
        }
        public List<Employee> GetEmployees()
        {
            var result = _context.Employees.FromSqlRaw<Employee>("SpListEmployees").ToList();
            return result;
        }

        public Employee GetEmployeeById(int id)
        {
            return _context.Employees.Find(id);
        }

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }
    }
}
