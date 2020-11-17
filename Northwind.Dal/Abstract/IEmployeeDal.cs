using Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace Northwind.Dal.Abstract
{
    public interface IEmployeeDal
    {
        List<Employee> GetEmployees();
        Employee GetEmployeeById(int id);
    }
}
