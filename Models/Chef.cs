using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace CandD.Models
{
    public class Chef
    {
        [Key]
        public int ChefId { get; set; }

        [Required (ErrorMessage ="Needs a Name!")]
        [MinLength(3,ErrorMessage ="Must be > 2 characters!")]
        public string Name { get; set; }

        [Required]
        [FutureDateAttribute]
        public DateTime Birthday{ get; set; }


        public List<Dish> Dishes {get;set;}
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value is DateTime)
            {
                DateTime checkMe = (DateTime)value;
                if(checkMe > DateTime.Now)
                {
                    return new ValidationResult("That's the Future");                        
                }
                else 
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                return new ValidationResult("Not a date");
            }
        }
    }
}
