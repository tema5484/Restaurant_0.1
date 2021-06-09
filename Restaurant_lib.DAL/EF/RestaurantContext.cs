using System;
using System.Data.Entity;
using System.Linq;
using Restaurant_lib.DAL.Entity;

namespace Restaurant_lib.DAL.EF
{
    public class RestaurantContext : DbContext
    {

        public RestaurantContext() : base("name=TestRestaurantContext") { }

        public DbSet<Dish> Menu { get; set; }
        public DbSet<Order> OrderList { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
    }
}