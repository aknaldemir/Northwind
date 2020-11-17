using Microsoft.EntityFrameworkCore;
using Northwind.Entities.Concrete;

namespace Northwind.Dal.Concrete.EntityFramework.Contexts
{
    public class NorthwindContext:DbContext
    {
        public NorthwindContext(DbContextOptions<NorthwindContext> options):base(options)
        { }
        public DbSet<Employee> Employees { get; set; }
    }
}
