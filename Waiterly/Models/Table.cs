using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Waiterly.Models
{
    public class Table
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int TableNumber { get; set; }
        [Required]
        public int Seats { get; set; }
        [Required]
        public int RestaurantId { get; set; }
        [NotMapped]
        public Restaurant Restaurant { get; set; }
    }
}
