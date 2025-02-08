using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Entities
{
    public class Position
    {
        [Key]
        public int PositionId { get; set; }
        [Required, MaxLength(30)]
        public string PositionName { get; set; }

        public Position(string positionName)
        {
            PositionName = positionName;
        }
    }
}
