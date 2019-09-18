using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Waiterly.Models
{
    public class Wage
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Employee")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Required]
        public double Dollars { get; set; }

        [Required]
        public double Hours { get; set; }

        [Required]
        public int RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }

        [NotMapped]
        [Display(Name = "Payout")]
        public double Salary => Dollars * Hours;

    }
}
