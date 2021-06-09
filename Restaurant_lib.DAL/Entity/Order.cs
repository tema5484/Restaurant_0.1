using System;
using System.Collections.Generic;
using Restaurant_lib.DAL.Interfaces;

namespace Restaurant_lib.DAL.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public int Table { get; set; }
        public int DishNumber { get; set; }
        public decimal Sum { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
