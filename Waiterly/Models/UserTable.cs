﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Waiterly.Models
{
    public class UserTable
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int TableId { get; set; }
        [NotMapped]
        public ApplicationUser User { get; set; }
        [NotMapped]
        public Table Table { get; set; }
    }
}
