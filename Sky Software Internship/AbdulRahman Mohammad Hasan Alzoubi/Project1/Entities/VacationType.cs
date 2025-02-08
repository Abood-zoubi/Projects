using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Entities
{
    public class VacationType
    {
        [Key, MaxLength(1)]
        public string VacationTypeCode { get; set; }
        [MaxLength(20)]
        public string VacationName { get; set; }
    }
}
