using DevExpress.Web.Mvc;
using Northwind.DevExpress.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Northwind.DevExpress.UI.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly NorthwindEntities _dbContext;

        public HomeController()
        {
            _dbContext = new NorthwindEntities();
        }

        public async Task<ActionResult> Index()
        {
            //_client.BaseAddress = new Uri("https://localhost:44357/api/");
            //HttpResponseMessage response = await _client.GetAsync("employees");
            //var json = response.Content.ReadAsStringAsync().Result;
            //var employees = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(json);

            var employees = _dbContext.Employees.ToList();
            return View(employees);
        }

        Northwind.DevExpress.UI.Models.NorthwindEntities db = new Northwind.DevExpress.UI.Models.NorthwindEntities();

        [ValidateInput(false)]
        public ActionResult GridViewPartialEmployee()
        {
            var model = db.Employees;
            return PartialView("_GridViewPartialEmployee", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialEmployeeAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Northwind.DevExpress.UI.Models.Employee item)
        {
            var model = db.Employees;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartialEmployee", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialEmployeeUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Northwind.DevExpress.UI.Models.Employee item)
        {
            var model = db.Employees;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.EmployeeID == item.EmployeeID);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartialEmployee", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialEmployeeDelete(System.Int32 EmployeeID)
        {
            var model = db.Employees;
            if (EmployeeID >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.EmployeeID == EmployeeID);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridViewPartialEmployee", model.ToList());
        }
    }
}