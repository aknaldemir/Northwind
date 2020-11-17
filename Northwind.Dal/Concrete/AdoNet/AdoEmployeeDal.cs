﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Northwind.Dal.Abstract;
using Northwind.Entities.Concrete;

namespace Northwind.Dal.Concrete.AdoNet
{
    public class AdoEmployeeDal : IEmployeeDal
    {
        private readonly SqlConnection _connection;
        public AdoEmployeeDal()
        {
            _connection = new SqlConnection("Server=AKIN\\SQLEXPRESS;Database=Northwind;Integrated Security=true;");
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            SqlCommand command = new SqlCommand("SpListEmployees", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            _connection.Open();
            var sqlDataReader = command.ExecuteReader();
            Employee employee;
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    employee = new Employee();
                    employee.EmployeeId = (int)(sqlDataReader["EmployeeId"]);
                    employee.LastName = sqlDataReader["LastName"].ToString();
                    employee.FirstName = sqlDataReader["FirstName"].ToString();
                    employee.Title = sqlDataReader["Title"].ToString() ?? "";
                    employee.TitleOfCourtesy = sqlDataReader["TitleOfCourtesy"].ToString() ?? "";
                    employee.BirthDate = (DateTime)sqlDataReader["BirthDate"];
                    employee.HireDate = (DateTime)sqlDataReader["HireDate"];
                    employee.Address = sqlDataReader["Address"].ToString() ?? "";
                    employee.City = sqlDataReader["City"].ToString() ?? "";
                    employee.Region = sqlDataReader["Region"].ToString() ?? "";
                    employee.PostalCode = sqlDataReader["PostalCode"].ToString() ?? "";
                    employee.Country = sqlDataReader["Country"].ToString() ?? "";
                    employee.HomePhone = sqlDataReader["HomePhone"].ToString() ?? "";
                    employee.Extension = sqlDataReader["Extension"].ToString() ?? "";
                    employee.Notes = sqlDataReader["Notes"].ToString() ?? "";
                    employee.ReportsTo = sqlDataReader["ReportsTo"] != DBNull.Value ? (int)sqlDataReader["ReportsTo"] : 0;
                    //Add list  
                    employees.Add(employee);
                }
            }

            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            SqlCommand command = new SqlCommand("SP_GET_EMPLOYEE_BY_ID", _connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.Add("@EmployeeId", System.Data.SqlDbType.Int).Value = id;
            _connection.Open();
            var sqlDataReader = command.ExecuteReader();

            Employee employee;

            if (sqlDataReader.HasRows)
            {
                employee = new Employee();
                while (sqlDataReader.Read())
                {
                    employee.EmployeeId = sqlDataReader.GetInt32(0);
                    employee.LastName = sqlDataReader.GetString(1);
                    employee.FirstName = sqlDataReader.GetString(2);
                    employee.Title = sqlDataReader.GetString(3);
                    employee.TitleOfCourtesy = sqlDataReader.GetString(4);
                    employee.BirthDate = sqlDataReader.GetDateTime(5);
                    employee.HireDate = sqlDataReader.GetDateTime(6);
                    employee.Address = sqlDataReader.GetString(7);
                    employee.City = sqlDataReader.GetString(8);
                    employee.Region = sqlDataReader.GetString(9);
                    employee.PostalCode = sqlDataReader.GetString(10);
                    employee.Country = sqlDataReader.GetString(11);
                    employee.HomePhone = sqlDataReader.GetString(12);
                    employee.Extension = sqlDataReader.GetString(13);
                    employee.Notes = sqlDataReader.GetString(14);
                    employee.ReportsTo = sqlDataReader.GetInt32(15);
                }
            }
            else
                throw new Exception("Kayıt yok.");
            _connection.Close();

            return employee;


        }
    }
}
