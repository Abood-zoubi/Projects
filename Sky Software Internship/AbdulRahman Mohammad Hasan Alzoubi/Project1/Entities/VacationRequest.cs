using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Entities
{
    public class VacationRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestId { get; set; }
        [Required]
        public DateTime RequestSubmissionDate { get; set; }
        [Required, MaxLength(100)]
        public string Description { get; set; }
        public int EmployeeNumber { get; set; }
        public string VacationTypeCode { get; set; }
        [Required]
        public DateOnly StartDate { get; set; }
        [Required]
        public DateOnly EndDate { get; set; }
        [Required]
        public int TotalVacationDays { get; set; }
        [Required]
        public int StateId { get; set; }
        public int? ApprovedByEmpNum { get; set; }
        public int? DeclinedByEmpNum { get; set; }
        public Employee Employee { get; set; }
        public VacationType VacationType { get; set; }
        public RequestState RequestState { get; set; }
    }
}
