using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDatabaseFirst.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace EFDatabaseFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var DbContext = new CompanySystemContext();

            var employees = (from emp in DbContext.Employees
                             select new
                             {
                                 emp.FirstName,
                                 emp.LastName,
                                 DepartmentName = emp.Department.DepartmentName,
                                 emp.HireDate
                             })
                             .ToList();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("First Query");
            Console.WriteLine("------------------------------------------------------------------------------------");
            
            foreach (var emp in employees)
            {
                Console.WriteLine($"Employee: {emp.FirstName} {emp.LastName}, Department: {emp.DepartmentName}, Hire Date: {emp.HireDate}");
            }
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine("Second Query");
            Console.WriteLine("------------------------------------------------------------------------------------");
            

            var departments = (from dep in DbContext.Departments
                               select new
                               {
                                   dep.DepartmentName,
                                   Employees = dep.Employees.Select(e => e.FirstName + " " + e.LastName).ToList()
                               }).ToList();


            foreach (var dep in departments)
            {
                Console.WriteLine($"Department: {dep.DepartmentName}");
                if (dep.Employees != null)
                {
                    foreach (var emp in dep.Employees)
                    {
                        if (emp != null)
                        {
                            Console.WriteLine($"Employee: {emp}");
                        }

                    }
                }
                else
                {
                    Console.WriteLine($"Employee: null");
                }
            }
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine("Third Query");
            Console.WriteLine("------------------------------------------------------------------------------------");
            

            var departmentsWithMoreThanOneEmployee = (from dep in DbContext.Departments
                                                      where dep.Employees.Count > 1 
                                                      select new
                                                       {
                                                        dep.DepartmentName,
                                                        EmployeeCount = dep.Employees.Count 
                                                       })
                                                    .ToList();

            foreach (var dep in departmentsWithMoreThanOneEmployee)
            {
                Console.WriteLine($"Department: {dep.DepartmentName}, Employee Count: {dep.EmployeeCount}");
            }
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine("Fourth Query");
            Console.WriteLine("------------------------------------------------------------------------------------");
            

            var departmentsWithEmployeesAbove5000 = (from dep in DbContext.Departments
                                                     let employeesAbove5000 = dep.Employees
                                                     .Where(emp => emp.Salaries
                                                     .Any(salary => salary.Salary1 > 5000))
                                                     where employeesAbove5000.Count() > 1
                                                     select new
                                                     {
                                                         dep.DepartmentName,
                                                         EmployeeCount = employeesAbove5000.Count()
                                                     })
                                                     .ToList();

            foreach (var dep in departmentsWithEmployeesAbove5000)
            {
                Console.WriteLine($"Department: {dep.DepartmentName}, Employee Count of Salary above 5000): {dep.EmployeeCount}");
            }
            Console.ResetColor();
        }
    }
}