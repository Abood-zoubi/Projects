using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Project1.Entities;

namespace Project1
{
    internal class Program
    {
        static void Main()
        {
            using var dbContext = new EFCoreDbContext();
            //Add20Departments(dbContext);
            //Add20Positions(dbContext);
            //Add10Employees(dbContext);
            //AddEmployees(dbContext);

            while (true)
            {
                Console.WriteLine("Main Menu:");
                Console.WriteLine("1. Update Employee Info");
                Console.WriteLine("2. Submit Vacation Request");
                Console.WriteLine("3. Process Pending Vacation Requests");
                Console.WriteLine("4. Show All Employees");
                Console.WriteLine("5. Get Employee by Number");
                Console.WriteLine("6. Get Employees with Pending Requests");
                Console.WriteLine("7. Get Employee Vacation History");
                Console.WriteLine("8. Get Pending Vacation Requests");
                Console.WriteLine("9. Exit");
                Console.Write("Enter choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Employee Number to Update: ");
                        int employeeNum = int.Parse(Console.ReadLine());
                        UpdateEmployee(dbContext, employeeNum);
                        break;
                    case 2:
                        Console.WriteLine("Enter Your Employee Number: ");
                        int eNum = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Vacation Type Code: ");
                        string typeCode = Console.ReadLine();

                        Console.Write("Enter Vacation Start Year: ");
                        int StartYear = int.Parse(Console.ReadLine());

                        Console.Write("Enter Vacation Start month: ");
                        int StartMonth = int.Parse(Console.ReadLine());

                        Console.Write("Enter Vacation Start Day: ");
                        int StartDay = int.Parse(Console.ReadLine());

                        var StartDate = new DateOnly(StartYear, StartMonth, StartDay);

                        Console.Write("Enter Vacation End Year: ");
                        int EndYear = int.Parse(Console.ReadLine());

                        Console.Write("Enter Vacation End month: ");
                        int EndMonth = int.Parse(Console.ReadLine());

                        Console.Write("Enter Vacation End Day: ");
                        int EndDay = int.Parse(Console.ReadLine());

                        var EndDate = new DateOnly(EndYear, EndMonth, EndDay);

                        Console.WriteLine("Enter Vacation Description: ");
                        string description = Console.ReadLine();

                        SubmitVacationRequest(dbContext, eNum, typeCode, StartDate, EndDate, description);
                        break;
                    case 3:
                        Console.WriteLine("Are you an admin ?");
                        string ans = Console.ReadLine();
                        if (ans == "yes" || ans == "y")
                        {
                            Console.WriteLine("Enter you Employee ID: ");
                            int id = int.Parse(Console.ReadLine());
                            VacationRequestStatus(dbContext, id);
                        }
                        break;

                    case 4:
                        getAllEmployeeInfo(dbContext);
                        break;
                    case 5:
                        Console.WriteLine("Enter Employee Number you want to get history of: ");
                        int num = int.Parse(Console.ReadLine());
                        getEmployeeInfo(dbContext, num);
                        break;
                    case 6:
                        GetEmployeesWithPendingVacationRequests(dbContext);
                        break;
                    case 7:
                        Console.WriteLine("Enter Employee Number you want to get history of: ");
                        int empNum = int.Parse(Console.ReadLine());
                        GetApprovedVacationRequests(dbContext, empNum);
                        break;
                    case 8:
                        GetPendingVacationRequests(dbContext);
                        break;
                    case 9:
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }
        

        private static void Add20Departments(EFCoreDbContext dbContext)
        {
            dbContext.AddRange(
            new Department("IT"),
            new Department("Engineering"),
            new Department("Financial"),
            new Department("HR"),
            new Department("Training"),
            new Department("Security"),
            new Department("Legal"),
            new Department("Clinical"),
            new Department("Research"),
            new Department("Marketing"),
            new Department("Sales"),
            new Department("Customer Support"),
            new Department("Operations"),
            new Department("Public Relations"),
            new Department("Quality Assurance"),
            new Department("Management"),
            new Department("Business Development"),
            new Department("Compliance"),
            new Department("Data Analytics")
            );

            dbContext.SaveChanges();
        }

        private static void Add20Positions(EFCoreDbContext dbContext)
        {
            var position1 = new Position("Manager");
            var position2 = new Position("Vice Manager");
            var position3 = new Position("Team Leader");
            var position4 = new Position("Senior Developer");
            var position5 = new Position("Junior Developer");
            var position6 = new Position("Hr Officer");
            var position7 = new Position("Marketing Officer");
            var position8 = new Position("Sales Representative");
            var position9 = new Position("Parallegal");
            var position10 = new Position("Lawyer");
            var position11 = new Position("Customer Support Agent");
            var position12 = new Position("Trainer");
            var position13 = new Position("Research Scientist");
            var position14 = new Position("Security Officer");
            var position15 = new Position("Public Relations Executive");
            var position16 = new Position("Administrative Assistant");
            var position17 = new Position("Compliance Officer");
            var position18 = new Position("Business Analyst");
            var position19 = new Position("Intern");
            var position20 = new Position("Chief Executive Officer");

            dbContext.Positions.Add(position1);
            dbContext.Positions.Add(position2);
            dbContext.Positions.Add(position3);
            dbContext.Positions.Add(position4);
            dbContext.Positions.Add(position5);
            dbContext.Positions.Add(position6);
            dbContext.Positions.Add(position7);
            dbContext.Positions.Add(position8);
            dbContext.Positions.Add(position9);
            dbContext.Positions.Add(position10);
            dbContext.Positions.Add(position11);
            dbContext.Positions.Add(position12);
            dbContext.Positions.Add(position13);
            dbContext.Positions.Add(position14);
            dbContext.Positions.Add(position15);
            dbContext.Positions.Add(position16);
            dbContext.Positions.Add(position17);
            dbContext.Positions.Add(position18);
            dbContext.Positions.Add(position19);
            dbContext.Positions.Add(position20);

            dbContext.SaveChanges();

        }

        private static void Add10Employees(EFCoreDbContext dbContext)
        {
            var employees = new List<Employee>
            { 
                new Employee("John Doe", 1, 1, "M", null, 5000),  // No ReportedToEmpNum yet
                new Employee("Jane Smith", 2, 2, "F", null, 4800),
                new Employee("Michael Brown", 3, 3, "M", null, 5100),
                new Employee("Emily Johnson", 1, 4, "F", null, 4700),
                new Employee("David Wilson", 2, 5, "M", null, 5300),
                new Employee("Sarah Davis", 3, 6, "F", null, 4900),
                new Employee("Chris Miller", 4, 7, "M", null, 5200),
                new Employee("Anna White", 5, 8, "F", null, 5000),
                new Employee("Robert Taylor", 6, 9, "M", null, 5400),
                new Employee("Jessica Moore", 7, 10, "F", null, 5500)
            };

        dbContext.Employees.AddRange(employees);
        dbContext.SaveChanges();

        // After saving, assign the ReportedToEmpNum values
        employees[1].ReportedToEmpNum = employees[0].EmployeeNumber; // Jane Smith reports to John Doe
        employees[2].ReportedToEmpNum = employees[1].EmployeeNumber; // Michael Brown reports to Jane Smith
        employees[3].ReportedToEmpNum = employees[2].EmployeeNumber; // Emily Johnson reports to Michael Brown
        employees[4].ReportedToEmpNum = employees[3].EmployeeNumber; // David Wilson reports to Emily Johnson
        employees[5].ReportedToEmpNum = employees[4].EmployeeNumber; // Sarah Davis reports to David Wilson
        employees[6].ReportedToEmpNum = employees[5].EmployeeNumber; // Chris Miller reports to Sarah Davis
        employees[7].ReportedToEmpNum = employees[6].EmployeeNumber; // Anna White reports to Chris Miller
        employees[8].ReportedToEmpNum = employees[7].EmployeeNumber; // Robert Taylor reports to Anna White
        employees[9].ReportedToEmpNum = employees[8].EmployeeNumber; // Jessica Moore reports to Robert Taylor

        // Save the updated relationships
        dbContext.SaveChanges();
        }

        private static void UpdateEmployee(EFCoreDbContext dbContext, int empNum)
        {
            var employee = dbContext.Employees.Where(e => e.EmployeeNumber == empNum).FirstOrDefault();

            if (employee != null)
            {
                Console.Write("Enter new Name: ");
                employee.EmployeeName = Console.ReadLine();

                Console.WriteLine("Available Departments:");
                var departments = dbContext.Departments.ToList();
                foreach (var dept in departments)
                {
                    Console.WriteLine($"{dept.DepartmentId}: {dept.DepartmentName}");
                }

                Console.Write("Enter new Department ID: ");
                employee.DepartmentId = int.Parse(Console.ReadLine());

                Console.WriteLine("Available Positions:");
                var positions = dbContext.Positions.ToList();
                foreach (var position in positions)
                {
                    Console.WriteLine($"{position.PositionId}: {position.PositionName}");
                }

                Console.Write("Enter new Position ID: ");
                employee.PositionId = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter New Salary");
                employee.Salary = decimal.Parse(Console.ReadLine());

                dbContext.SaveChanges();
                Console.WriteLine("Employee details updated successfully!");
            }

        }

        private static void UpdateVacationDays(EFCoreDbContext dbContext, int requestId)
        {
            var vacationRequest = dbContext.VacationRequests.Where(vr => vr.RequestId == requestId).FirstOrDefault();
            if (vacationRequest != null)
            {
                if (vacationRequest.StateId == 2)
                {
                    var employee = dbContext.Employees.Where(e => e.EmployeeNumber == vacationRequest.EmployeeNumber).FirstOrDefault();
                    if (employee != null)
                    {
                        if (employee.VacationDaysLeft > vacationRequest.TotalVacationDays)
                        {
                            employee.VacationDaysLeft -= vacationRequest.TotalVacationDays;
                        }
                        else
                        {
                            Console.WriteLine("Employee does not have enough vacation days left.");
                            vacationRequest.StateId = 3;
                            employee.VacationDaysLeft = 0;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Employee Not Found");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Vacation Not Approved");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Vacation request not found.");
                return;
            }
            dbContext.SaveChanges();
        }

        private static bool SubmitVacationRequest(EFCoreDbContext dbContext, int employeeNumber, string vacationTypeCode, DateOnly startDate, DateOnly endDate, string description)
        {
            var employee = dbContext.Employees.Where(e => e.EmployeeNumber == employeeNumber).FirstOrDefault();
            if (employee == null)
            {
                Console.WriteLine("Employee not found.");
                return false;
            }

            bool overlap = dbContext.VacationRequests.Any(vr =>
            vr.EmployeeNumber == employeeNumber &&
            ((startDate >= vr.StartDate && startDate <= vr.EndDate) || // New start date is inside existing vacation
            (endDate >= vr.StartDate && endDate <= vr.EndDate) ||     // New end date is inside existing vacation
            (startDate <= vr.StartDate && endDate >= vr.EndDate))    // New vacation fully overlaps existing vacation
            );

            if (overlap)
            {
                Console.WriteLine("vacation overlaps with other request.");
                return false;
            }

            int totalVacationDays = endDate.DayNumber - startDate.DayNumber + 1;

            if (employee.VacationDaysLeft < totalVacationDays)
            {
                Console.WriteLine("Not Enough vacation days left.");
                return false;
            }

            var vacationRequest = new VacationRequest
            {
                RequestSubmissionDate = DateTime.Now,
                EmployeeNumber = employeeNumber,
                VacationTypeCode = vacationTypeCode,
                StartDate = startDate,
                EndDate = endDate,
                TotalVacationDays = totalVacationDays,
                StateId = 1,
                Description = description
            };

            dbContext.VacationRequests.Add(vacationRequest);
            dbContext.SaveChanges();

            Console.WriteLine("Vacation request submitted successfully.");
            return true;
        }

        private static void VacationRequestStatus(EFCoreDbContext dbContext, int decidedByEmpNum)
        {
            var pendingRequests = dbContext.VacationRequests.Where(vr => vr.StateId == 1).ToList();

            if (pendingRequests.Count == 0)
            {
                Console.WriteLine("No pending vacation requests.");
                return;
            }

            Console.WriteLine("Pending Vacation Requests:");
            foreach (var request in pendingRequests)
            {
                Console.WriteLine($"Request ID: {request.RequestId}, Employee Number: {request.EmployeeNumber}, Start Date: {request.StartDate}, End Date: {request.EndDate}, Description: {request.Description}");
            }

            Console.Write("Enter the Request ID to process: ");
            int requestId = int.Parse(Console.ReadLine());

            var vacationRequest = dbContext.VacationRequests.Where(vr => vr.RequestId == requestId).FirstOrDefault();

            if (vacationRequest != null)
            {
                Console.WriteLine("Select an action:");
                Console.WriteLine("1. Approve");
                Console.WriteLine("2. Decline");
                Console.Write("Enter your choice (1 or 2): ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    vacationRequest.StateId = 2;
                    vacationRequest.ApprovedByEmpNum = decidedByEmpNum;
                    vacationRequest.TotalVacationDays -= vacationRequest.EndDate.DayNumber - vacationRequest.StartDate.DayNumber - 1;
                    UpdateVacationDays(dbContext, vacationRequest.RequestId);
                    Console.WriteLine("Vacation request approved.");
                }
                else if (choice == 2)
                {
                    vacationRequest.StateId = 3;
                    vacationRequest.DeclinedByEmpNum = decidedByEmpNum;
                    Console.WriteLine("Vacation request declined.");
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }

                dbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("Vacation request not found.");
            }
        }

        private static void AddEmployees(EFCoreDbContext dbContext)
        {
            var random = new Random();
            var departmentsCount = dbContext.Departments.Count();
            var positionsCount = dbContext.Positions.Count();

            List<string> firstNames = new List<string> { "John", "Alice", "Michael", "Emma", "David", "Sophia", "James", "Olivia", "Robert", "Ava" };
            List<string> lastNames = new List<string> { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez" };

            List<Employee> employees = new List<Employee>();

            var positionIds = dbContext.Positions.Select(p => p.PositionId).ToList();

            for (int i = 1; i <= 100; i++)
            {

                var firstName = firstNames[random.Next(firstNames.Count)];
                var empName = firstName;
                var departmentId = random.Next(1, departmentsCount + 1);
                var positionId = random.Next(1, positionsCount + 1);
                var genderCode = random.Next(0, 2) == 0 ? "M" : "F";
                //var reportedToEmpNum = random.Next(1, i); // Assigns a previous employee as a manager
                var salary = random.Next(5000, 15000); // Salary between 5k and 15k

                employees.Add(new Employee
                {
                    EmployeeName = empName,
                    DepartmentId = departmentId,
                    PositionId = positionIds[random.Next(positionIds.Count)],
                    GenderCode = genderCode,
                    ReportedToEmpNum = null,
                    VacationDaysLeft = 24,
                    Salary = salary
                });
            }

            dbContext.AddRange(employees);
            dbContext.SaveChanges();

            for (int i = 1; i < employees.Count; i++)
            {
                // Randomly assign a manager from earlier employees
                var reportedToEmpNum = employees[random.Next(0, i)].EmployeeNumber;
                employees[i].ReportedToEmpNum = reportedToEmpNum;
            }

            dbContext.SaveChanges();
        }

        private static void getAllEmployeeInfo(EFCoreDbContext dbContext)
        {
            var employees = (from emp in dbContext.Employees
                             select new
                             {
                                 emp.EmployeeNumber,
                                 emp.EmployeeName,
                                 emp.Department.DepartmentName,
                                 emp.Salary
                             }).ToList();

            foreach (var emp in employees)
            {
                Console.WriteLine($"Emp No: {emp.EmployeeNumber}, Name: {emp.EmployeeName}, Dept: {emp.DepartmentName}, Salary: {emp.Salary}");
            }
        }

        private static void getEmployeeInfo(EFCoreDbContext dbContext, int empNum)
        {
            var employee = (from emp in dbContext.Employees
                            where emp.EmployeeNumber == empNum
                            select new
                            {
                                emp.EmployeeNumber,
                                emp.EmployeeName,
                                DepartmentName = emp.Department.DepartmentName,
                                PositionName = emp.Position.PositionName,
                                ReportedToEmployeeName = dbContext.Employees
                                .Where(r => r.EmployeeNumber == emp.ReportedToEmpNum)
                                .Select(r => r.EmployeeName)
                                .FirstOrDefault(),
                                emp.VacationDaysLeft
                            }).FirstOrDefault();

            if (employee != null)
            {
                Console.WriteLine("Employee Details:");
                Console.WriteLine($"Employee Number: {employee.EmployeeNumber}");
                Console.WriteLine($"Name: {employee.EmployeeName}");
                Console.WriteLine($"Department: {employee.DepartmentName}");
                Console.WriteLine($"Position: {employee.PositionName}");
                Console.WriteLine($"Reports To: {employee.ReportedToEmployeeName ?? "None"}");
                Console.WriteLine($"Vacation Days Left: {employee.VacationDaysLeft}");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }


        }

        private static void GetEmployeesWithPendingVacationRequests(EFCoreDbContext dbContext)
        {
            var employees = dbContext.Employees
                .Where(e => dbContext.VacationRequests
                .Any(vr => vr.EmployeeNumber == e.EmployeeNumber && vr.StateId == 1))
                .Select(emp => new
                {
                    emp.EmployeeNumber,
                    emp.EmployeeName
                }).ToList();

            if (employees.Count == 0)
            {
                Console.WriteLine("No employees with pending vacation requests.");
                return;
            }

            Console.WriteLine("Employees with Pending Vacation Requests:");
            foreach (var emp in employees)
            {
                Console.WriteLine($"Employee Number: {emp.EmployeeNumber}, Name: {emp.EmployeeName}");
            }
        }

        private static void GetApprovedVacationRequests(EFCoreDbContext dbContext, int employeeNumber)
        {
            var approvedRequests = dbContext.VacationRequests
                                    .Where(vr => vr.EmployeeNumber == employeeNumber && vr.StateId == 2)
                                    .Select(vr => new
                                    {
                                        VacationType = vr.VacationType.VacationName,
                                        vr.Description,
                                        RequestDuration = $"{vr.StartDate:yyyy-MM-dd} to {vr.EndDate:yyyy-MM-dd}",
                                        vr.TotalVacationDays,
                                        ApprovedByEmployeeName = dbContext.Employees
                                        .Where(e => e.EmployeeNumber == vr.ApprovedByEmpNum)
                                        .Select(e => e.EmployeeName)
                                        .FirstOrDefault() // Get the name of the approver
                                    }).ToList();


            if (!approvedRequests.Any())
            {
                Console.WriteLine("No approved vacation requests found for this employee.");
                return;
            }

            Console.WriteLine($"Approved Vacation Requests for Employee {employeeNumber}:");
            foreach (var request in approvedRequests)
            {
                Console.WriteLine($"- Vacation Type: {request.VacationType}");
                Console.WriteLine($"  Description: {request.Description}");
                Console.WriteLine($"  Duration: {request.RequestDuration} ({request.TotalVacationDays} days)");
                Console.WriteLine($"  Approved By: {request.ApprovedByEmployeeName}");
                Console.WriteLine("--------------------------------");
            }
        }

        private static void GetPendingVacationRequests(EFCoreDbContext dbContext)
        {
            var pendingRequests = (from vr in dbContext.VacationRequests
                                   join emp in dbContext.Employees on vr.EmployeeNumber equals emp.EmployeeNumber
                                   where vr.StateId == 1
                                   select new
                                   {
                                       vr.Description,
                                       emp.EmployeeNumber,
                                       emp.EmployeeName,
                                       SubmittedOn = vr.RequestSubmissionDate,
                                       VacationDuration = vr.TotalVacationDays >= 7 ? $"{vr.TotalVacationDays / 7} weeks {vr.TotalVacationDays % 7} days": $"{vr.TotalVacationDays} days",
                                       StartDate = vr.StartDate,
                                       EndDate = vr.EndDate,
                                       emp.Salary
                                   }).ToList();

            if (!pendingRequests.Any())
            {
                Console.WriteLine("No pending vacation requests.");
                return;
            }

            Console.WriteLine("Pending Vacation Requests:");
            foreach (var request in pendingRequests)
            {
                Console.WriteLine($"Description: {request.Description}");
                Console.WriteLine($"Employee Number: {request.EmployeeNumber}");
                Console.WriteLine($"Employee Name: {request.EmployeeName}");
                Console.WriteLine($"Submitted On: {request.SubmittedOn:yyyy-MM-dd}");
                Console.WriteLine($"Vacation Duration: {request.VacationDuration}");
                Console.WriteLine($"Start Date: {request.StartDate:yyyy-MM-dd}");
                Console.WriteLine($"End Date: {request.EndDate:yyyy-MM-dd}");
                Console.WriteLine($"Employee Salary: {request.Salary}");
            }
        }
    }
}
