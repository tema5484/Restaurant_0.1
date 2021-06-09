using System;
using System.Collections.Generic;
using Restaurant_lib.DAL.EF;
using Restaurant_lib.DAL.Interfaces;
using System.Data.Entity;
using System.Linq;
using Restaurant_lib.DAL.Entity;

namespace Restaurant_lib.DAL.Repositories
{
    class DishRepository : IRepository<Dish>
    {
        private RestaurantContext db;

        public DishRepository(RestaurantContext context)
        {
            this.db = context;
        }

        public IEnumerable<Dish> GetAll()
        {
            return db.Menu;
        }

        public Dish Get(int id)
        {
            return db.Menu.Find(id);
        }

        public void Create(Dish dish)
        {
            db.Menu.Add(dish);
        }

        public void Update(Dish dish)
        {
            db.Entry(dish).State = EntityState.Modified;
        }

        public IEnumerable<Dish> Find(Func<Dish, Boolean> predicate)
        {
            return db.Menu.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Dish dish = db.Menu.Find(id);
            if (dish != null)
                db.Menu.Remove(dish);
        }
    }
}
