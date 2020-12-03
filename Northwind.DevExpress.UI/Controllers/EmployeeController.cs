using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Northwind.DevExpress.UI.Models;
using Northwind.DevExpress.UI.ViewModels;

namespace Northwind.DevExpress.UI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly HttpClient _client;
        private readonly NorthwindEntities _dbContext;
        
        public EmployeeController(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient();
            _dbContext=new NorthwindEntities();
        }

        public EmployeeController()
        {
            
        }

        public async Task<PartialViewResult> EmployeesList()
        {
            //_client.BaseAddress = new Uri("https://localhost:44357/api/");
            //HttpResponseMessage response = await _client.GetAsync("employees");
            //var json = response.Content.ReadAsStringAsync().Result;
            //var employees = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(json);

            var employees = _dbContext.Employees.ToList();
            return PartialView("_EmployeesList", employees);
        }
    }
}