using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Waiterly.Models
{
    public class RestaurantUser
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Employee")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Required]
        [Display(Name = "Restaurant Name")]
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        public ICollection<Restaurant> Restaurants { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }

    }
}
