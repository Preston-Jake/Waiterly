using System.ComponentModel.DataAnnotations;

namespace Waiterly.Models
{
    public class Category
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
    }
}