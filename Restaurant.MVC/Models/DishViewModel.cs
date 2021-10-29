using Restaurant.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.MVC.Models
{
    public class DishViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Max 30 characters")]
        public string DishName { get; set; }

        [Required]
        public DishType DishType { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public Menu Menu { get; set; }
    }
}
