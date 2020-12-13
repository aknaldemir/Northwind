using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Northwind.DevExpress.UI.Models;
using Northwind.DevExpress.UI.ViewModels;

namespace Northwind.DevExpress.UI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly NorthwindEntities _dbContext;
        
        public EmployeeController()
        {
            _dbContext=new NorthwindEntities();
        }

        public ActionResult Index()
        {
            var model =new EmployeeViewModel()
            {
                Employee = _dbContext.Employees.FirstOrDefault(i => i.EmployeeID==2),
                Description = "Yeni bir personel",
                InsertedDate = DateTime.Now
            };
            return View(model);
        }

        public async Task<PartialViewResult> EmployeesList()
        {
            var employees = _dbContext.Employees.ToList();
            return PartialView("_EmployeesList", employees);
        }
    }
}