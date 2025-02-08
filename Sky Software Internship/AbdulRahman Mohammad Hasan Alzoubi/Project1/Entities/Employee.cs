using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Entities
{
    public class Employee
    {
        [Key, Required, MaxLength(6)]
        public int EmployeeNumber { get; set; }
        [Required, MaxLength(20)]
        public string EmployeeName { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        [MaxLength(1)]
        public string GenderCode { get; set; }
        [MaxLength(6)]
        public int? ReportedToEmpNum { get; set; }
        [Range(0, 24)]
        public int VacationDaysLeft { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary {  get; set; }
        public Department Department { get; set; }
        public Position Position { get; set; }

        [ForeignKey("ReportedToEmpNum")]
        public Employee ReportedToEmployee { get; set; }
        
        public Employee(string empName, int departmentId, int positionId, string genderCode, int? reportedToEmpNum, decimal salary)
        {

            EmployeeName = empName;
            DepartmentId = departmentId;
            PositionId = positionId;
            GenderCode = genderCode;
            ReportedToEmpNum = reportedToEmpNum;
            VacationDaysLeft = 24;
            Salary = salary;
        }
        public Employee() { }

    }
}
