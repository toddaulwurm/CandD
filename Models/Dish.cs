using System;
using System.ComponentModel.DataAnnotations;
namespace CandD.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }
        [Required (ErrorMessage ="Needs a Name!")]
        [MinLength(3,ErrorMessage ="Must be > 2 characters!")]
        public string Name { get; set; }
        [Required (ErrorMessage ="Please Select Calories!")]
        [Range(0, 3000, ErrorMessage ="Must be positive and < 3000")]
        public int Calories { get; set; }
        [Required]
        public int Tastiness {get;set;}
        [Required]
        public string Description { get; set; }
        [Required]
        public int ChefId {get;set;}
        public Chef Chef {get;set;}
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
