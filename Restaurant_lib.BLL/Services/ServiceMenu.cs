using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant_lib.DAL.Interfaces;
using Restaurant_lib.DAL.Entity;
using Restaurant_lib.DAL.Repositories;

namespace Restaurant_lib.BLL.Services
{
    public class ServiceMenu : IMenu
    {
        IUnitOfWork Database { get; set; }

        public ServiceMenu(IUnitOfWork uow) 
        {
            Database = uow;
        }


        public void AddDish(int orderId, string name, TimeSpan? cookingTime, decimal price)
        {
            if (name == null)
                throw new ValidationException("Не задано назву страви!", "");
            if (cookingTime == null)
                throw new ValidationException("Не задано час приготування!", "");
            var dish = new Dish
            {

            };
            Database.Menu.Create(dish);
            Database.Save(); 
        }

        public void RemoveDish(int id) 
        {
            if (Database.Menu.Get(id) == null)
                throw new ValidationException("Страву не знайдено!", "");
            Database.Menu.Delete(id);
            Database.Save();
        }
        public void ChangeName(int id, string name)
        {
            var dish = Database.Menu.Get(id);
            if (dish == null)
                throw new ValidationException("Страву не знайдено!", "dish is null");
            dish.Name = name;
            Database.Menu.Update(dish);
            Database.Save();
        }
        public void ChangePrice(int id, decimal newPrice) 
        {
            var dish = Database.Menu.Get(id);
            if (dish == null)
                throw new ValidationException("Страву не знайдено!", "dish is null");
                dish.Price = newPrice;
            Database.Menu.Update(dish);
            Database.Save();
        }
        public void ChangeCookingTime(int id, TimeSpan cookingTime) 
        {
            if (cookingTime == null)
                throw new ValidationException("","");
            var dish = Database.Menu.Get(id);
            if (dish == null)
                throw new ValidationException("Страву не знайдено!", "dish is null ");
            dish.CookingTime = cookingTime;
            Database.Menu.Update(dish);
            Database.Save();
        }
        public string GetDish(int id) 
        {
            var dish = Database.Menu.Get(id);

            return ($"Страва  {dish.Name}, час приготування  {dish.CookingTime}, ціна {dish.Price}, інгрідієнти:{getIngridients(dish)}");
        }
        public IEnumerable<string> GetDishes() 
        {
            var dishes = Database.Menu.GetAll();

            List<string> newDishes = new List<string>();
            foreach (var dish in dishes) {
                newDishes.Add($"Номер {dish.Id}, назва страви {dish.Name}, ціна {dish.Price}");
            }
            return newDishes;
        }
        private string getIngridients(Dish dish) {
            string ingredients = "";
            foreach(var ingredient in dish.Ingredients)
                ingredients += ingredient + ", /n ";
            return ingredients;
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
