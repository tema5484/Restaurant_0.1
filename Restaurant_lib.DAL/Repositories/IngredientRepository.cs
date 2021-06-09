using System;
using System.Collections.Generic;
using Restaurant_lib.DAL.Interfaces;
using Restaurant_lib.DAL.Entity;
using Restaurant_lib.DAL.EF;
using System.Data.Entity;
using System.Linq;

namespace Restaurant_lib.DAL.Repositories
{
    class IngredientRepository : IRepository<Ingredient>
    {
        RestaurantContext db;
        public IngredientRepository(RestaurantContext context)
        {
            this.db = context;
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return db.Ingredients;
        }

        public Ingredient Get(int id)
        {
            return db.Ingredients.Find(id);
        }

        public void Create(Ingredient ingredient)
        {
            db.Ingredients.Add(ingredient);
        }

        public void Update(Ingredient ingredient)
        {
            db.Entry(ingredient).State = EntityState.Modified;
        }

        public IEnumerable<Ingredient> Find(Func<Ingredient, Boolean> predicate)
        {
            return db.Ingredients.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Ingredient ingredient = db.Ingredients.Find(id);
            if (ingredient != null)
                db.Ingredients.Remove(ingredient);
        }
    }
}
