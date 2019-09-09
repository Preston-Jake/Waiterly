using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Waiterly.Models
{
    public class Wage
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public double Dollars { get; set; }
        [Required]
        public double Hours { get; set; }
        

    }
}
