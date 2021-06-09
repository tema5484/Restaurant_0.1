using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_lib.BLL.Interfaces;
using Restaurant_lib.DAL.Interfaces;
using Restaurant_lib.DAL.Entity;

namespace Restaurant_lib.BLL.Services
{
    public class ServiceOrder : IOrdersList
    {
        IUnitOfWork Database { get; set; }

        public ServiceOrder(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreateOrder(int dishNumber, int table, int sum) 
        {
            var order = new Order
            {
                DishNumber = dishNumber,
                Table = table,
                Sum = sum,
            };
            Database.Orders.Create(order);
            Database.Save();
        }
        public void DeleteOrder(int id) 
        {
            var order = Database.Orders.Get(id);
            if (order == null)
                throw new ValidationException("Замовлення не знайдено!","");
            Database.Orders.Delete(id);
            Database.Save();
        }
        public void ChangeDishNumber(int id, int dishNumber) 
        {
            var order = Database.Orders.Get(id);
            if (order == null)
                throw new ValidationException("Замовлення не знайдено!", "dish is null ");
            order.DishNumber = dishNumber;
            Database.Orders.Update(order);
            Database.Save();
        }
        public void ChangeSum(int id, decimal newSum) 
        {
            var order = Database.Orders.Get(id);
            if (order == null)
                throw new ValidationException("Замовлення не знайдено!", "dish is null ");
            order.Sum = newSum;
            Database.Orders.Update(order);
            Database.Save();
        }
        public void ChangeTable(int id, int newTable) 
        {
            var order = Database.Orders.Get(id);
            if (order == null)
                throw new ValidationException("Замовлення не знайдено!", "dish is null ");
            order.Table = newTable;
            Database.Orders.Update(order);
            Database.Save();
        }

        public string GetOrder(int id)
        {
            var order = Database.Orders.Get(id);
            if (order == null)
                throw new ValidationException("Замовлення не знайдено!", "dish is null ");
         
            return ($"Замовлення {order.Id}, стіл {order.Table}, Страви(а): {getDishes(order)},сума {order.Sum}");
        }

        public List<string> GetOrders()
        {
            List<string> result = new List<string>();
            foreach (var order in Database.Orders.GetAll())
                result.Add($"Замовлення {order.Id}, стіл {order.Table}, Страви(а): {getDishes(order)}, сумма {order.Sum}.");
            return result;
        }

        private string getDishes(Order order)
        {
            if (order == null)
                throw new ValidationException("Замовлення відсутнє!","");
            string dishes= "";
            foreach (var dish in order.Dishes)
                dishes += dish.Name + "/n";
            return dishes;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
