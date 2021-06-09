using System;
using Restaurant_lib.DAL.EF;
using Restaurant_lib.DAL.Interfaces;
using Restaurant_lib.DAL.Entity;

namespace Restaurant_lib.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private RestaurantContext db;
        private DishRepository dishRepository;
        private OrderRepository orderRepository;
        private IngredientRepository ingredientRepository;

        public EFUnitOfWork()
        {
            db = new RestaurantContext();
        }
        public IRepository<Dish> Menu
        {
            get
            {
                if (dishRepository == null)
                    dishRepository = new DishRepository(db);
                return dishRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }
        public IRepository<Ingredient> Ingredients
        {
            get
            {
                if (dishRepository == null)
                    dishRepository = new DishRepository(db);
                return ingredientRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
