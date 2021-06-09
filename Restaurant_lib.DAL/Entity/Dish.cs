using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Restaurant_lib.DAL.Interfaces;

namespace Restaurant_lib.DAL.Entity
{
    public class Dish
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        
        public TimeSpan? CookingTime { get; set; }
        public decimal Price { get; set; }

        public virtual Order Order { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
