using System;
using Restaurant_lib.BLL.Interfaces;
using Restaurant_lib.BLL.Services;
using Restaurant_lib.DAL.Repositories;

namespace Restaurant_lib.BLL
{
    public class Restaurant : IRestaurant
    {
        ServiceIngredients SIngredients;
        ServiceMenu SMenu;
        ServiceOrder SOrders;
        EFUnitOfWork uow;
        public Restaurant() 
        {
            uow = new EFUnitOfWork();

            SIngredients = new ServiceIngredients(uow);
            SMenu = new ServiceMenu(uow);
            SOrders = new ServiceOrder(uow);
        }

        public void Dispose()
        {
            SOrders.Dispose();
            SIngredients.Dispose();
            SMenu.Dispose();
        }


        public IIngredients ingredients
        {
            get 
            { 
                if (SIngredients == null)
                    SIngredients = new ServiceIngredients(uow);
                return SIngredients;
            }
        }

        public IMenu Menu
        {
            get
            {
                if (SMenu == null)
                    SMenu = new ServiceMenu(uow);
                return SMenu;
            }
        }

        public IOrdersList Orders
        {
            get
            {
                if (SOrders == null)
                    SOrders = new ServiceOrder(uow);
                return SOrders;
            }
        }
    }
}
