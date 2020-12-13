using System;
using Northwind.DevExpress.UI.Models;

namespace Northwind.DevExpress.UI.ViewModels
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }

        public string Description { get; set; }
        public DateTime InsertedDate { get; set; }

    }
}