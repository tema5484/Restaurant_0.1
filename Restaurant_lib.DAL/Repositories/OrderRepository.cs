using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Restaurant_lib.DAL.EF;
using Restaurant_lib.DAL.Interfaces;
using Restaurant_lib.DAL.Entity;

namespace Restaurant_lib.DAL.Repositories
{
    class OrderRepository : IRepository<Order>
    {
        private RestaurantContext db;

        public OrderRepository(RestaurantContext context)
        {
            this.db = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return (IEnumerable<Order>)db.OrderList;
        }

        public Order Get(int id)
        {
            return db.OrderList.Find(id);
        }

        public void Create(Order order)
        {
            db.OrderList.Add(order);
        }

        public void Update(Order order)
        {
            db.Entry(order).State = EntityState.Modified;
        }
        public IEnumerable<Order> Find(Func<Order, Boolean> predicate)
        {
            return (IEnumerable<Order>)db.OrderList.Include(o => o.Dishes).Where((Func<Order, bool>)predicate).ToList();
        }
        public void Delete(int id)
        {
            var order = db.OrderList.Find(id);
            if (order != null)
                db.OrderList.Remove(order);
        }
    }
}
