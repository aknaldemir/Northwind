using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Northwind.Mvc.UI.Models;

namespace Northwind.Mvc.UI.Controllers
{
    public class EmployeeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress=new Uri("https://localhost:44357/api/employees/");
            HttpResponseMessage response =await client.GetAsync("getemployees");
            var json=response.Content.ReadAsStringAsync().Result;

            var employees = JsonConvert.DeserializeObject<List<EmployeeModel>>(json);
            return View(employees);
        }

        public IActionResult GetEmployeeById()
        {
          

            return View();
        }
    }
}
