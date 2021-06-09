using System;
using System.Collections.Generic;

namespace Restaurant_lib.BLL.Interfaces
{
    public interface IOrdersList
    {
        void CreateOrder( int DishNumber , int Table ,int Sum );
        void DeleteOrder(int id);
        void ChangeDishNumber(int id, int dishNumber);
        void ChangeSum(int id, decimal newSum);
        void ChangeTable(int id, int newTable);
        string GetOrder(int id);
        List<string> GetOrders();
        void Dispose();
    }
}
