using System;
using Restaurant_lib.DAL.Entity;

namespace Restaurant_lib.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable 
    {
        IRepository<Dish> Menu { get; }
        IRepository<Order> Orders { get; }
        IRepository<Ingredient> Ingredients { get; }
        void Save();
    }
}
