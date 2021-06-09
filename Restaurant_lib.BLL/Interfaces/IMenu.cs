using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_lib.BLL
{
    public interface IMenu
    {
        void AddDish(int orderId, string name,TimeSpan? cookingTime, decimal price);
        void RemoveDish(int id);
        void ChangeName(int id, string name);
        void ChangePrice(int id, decimal newPrice);
        void ChangeCookingTime(int id, TimeSpan cookingTime);
        string GetDish(int id);
        IEnumerable<string> GetDishes();
        void Dispose();
    }
}
