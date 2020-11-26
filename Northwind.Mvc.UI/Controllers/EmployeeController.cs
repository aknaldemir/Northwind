using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Northwind.Mvc.UI.Models;

namespace Northwind.Mvc.UI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly HttpClient _client;
        public EmployeeController(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient();
        }

        public async Task<PartialViewResult> EmployeesList()
        {
            _client.BaseAddress=new Uri("https://localhost:44357/api/");
            HttpResponseMessage response =await _client.GetAsync("employees");
            var json=response.Content.ReadAsStringAsync().Result;
            var employees = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(json);
            return PartialView(employees);
        }

        public IActionResult GetEmployeeById()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeViewModel model)
        {
            _client.BaseAddress=new Uri("https://localhost:44357/api/employees");

            var response=await _client.PostAsync("", content: new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("FirstName",model.FirstName),
                new KeyValuePair<string, string>("LastName",model.LastName),
                new KeyValuePair<string, string>("City",model.City),
            })).ConfigureAwait(false);


            return View();
        }

       




    }
}
