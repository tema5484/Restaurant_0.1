using System;
using Restaurant_lib.BLL.Interfaces;

namespace Restaurant_lib.BLL.Interfaces
{
    interface IRestaurant
    {
        IIngredients ingredients { get; }
        IMenu Menu { get; }
        IOrdersList Orders { get; }
        void Dispose();
    }
}
