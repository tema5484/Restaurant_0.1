using System;
using System.Collections.Generic;
using Restaurant_lib.BLL.Interfaces;
using Restaurant_lib.DAL.Interfaces;
using Restaurant_lib.DAL.Entity;

namespace Restaurant_lib.BLL.Services
{
    public class ServiceIngredients: IIngredients
    {
        IUnitOfWork Database { get; set; }

        public ServiceIngredients(IUnitOfWork uow) 
        {
            Database = uow;
        }

        public void AddIngredient(int DishId, string ingredient)
        {
            
                if (ingredient == null || ingredient == "")
                    throw new ValidationException("Інгредієнт не знайдено!", "ingredient is null");

            var dish = Database.Menu.Get(DishId);
            if (dish == null)
                throw new ValidationException("Страву не знайдено!", "dish is null");

            Database.Ingredients.Update(new Ingredient { Dish = dish, Name = ingredient });
            Database.Save();
        }

        public void RemoveIngredient(string ingredient)
        {
            if (ingredient == null)
                throw new ValidationException("Відсутнє значення інгредієнту!", "");
            int id = -1;
            foreach (var i in Database.Ingredients.GetAll())
                if (i.Name == ingredient)
                {
                    id = i.Id;
                    break;
                }
            
            if (id == -1)
                throw new ValidationException("Інгредієнт не знайдено!", "");

            Database.Ingredients.Delete(id);
            Database.Save();
        }

        public void ReplaceIngredient(string newIgredient, string ingredient)
        {
            if (ingredient == null)
                throw new ValidationException("Відсутнє значення інгредієнту!", "");
            int id = -1;
            foreach (var DI in Database.Ingredients.GetAll())
                if (DI.Name == ingredient)
                {
                    id = DI.Id;
                    break;
                }
            if(id == -1)
            throw new ValidationException("Інгредієнт не знайдено", "");
            var i = Database.Ingredients.Get(id);
            i.Name = newIgredient;
            Database.Ingredients.Update(i); 
            Database.Save();
        }

        public List<string> GetIngredients(int DishId)
        {
            var ingredients = new List<string>();
            foreach (var ingredient in Database.Menu.Get(DishId).Ingredients) 
            {
                ingredients.Add(ingredient.Name);
            }
            if (ingredients.Count < 1)
                throw new ValidationException("Інгредієнт не знайдено!","");
            return ingredients;
        }
        public List<string> searchIngredient(string ingredient) {
            if (ingredient == null)
                throw new ValidationException("Порожнє значення пошуку!","");

            List<string> result = new List<string>();

            foreach (var iid in Database.Ingredients.GetAll()) 
            {
                //перевірка 
                if (iid.Name.ToLower() == ingredient.ToLower()) 
                {
                    result.Add($"Інгредієнт { iid.Name} в страві {iid.Dish.Name}");
                }
                    
            }
            if (result.Count == 0)
                throw new Exception("Інгредієнт не знайдено!");
            return result;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
