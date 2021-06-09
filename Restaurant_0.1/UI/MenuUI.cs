using System;
using Restaurant_lib.BLL;

namespace Restaurant_lib.PL.UI
{
    public class MenuUI
    {
        Restaurant restaurant;
        MenuUI()
        {
            // BLL створення екземпляру
            restaurant = new Restaurant();

            Console.WriteLine("Інтерфейс для роботи з меню створено.");

            try
            {
                FunctionsDish();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                restaurant.Dispose();
            }
        }

        void FunctionsDish()
        {
            var command = Console.ReadLine().ToLower();
            while (command != "back")
            {
                switch (command)
                {
                    case "список страв":
                        CPrintAllDish();
                        break;
                    case "додати страву":
                        CAddDish();
                        break;

                    case "видалити страву":
                        CRemoveDish();
                        break;

                    case "змінити страву":
                        CChangeDish();
                        break;
                    case "знайти страву":
                        FindDish();
                        break;
                    case "back":
                        Console.WriteLine("Вихід з меню...");
                        break;
                    default:
                        Console.WriteLine("Невірна команда!");
                        Console.WriteLine("Список команд: список страв, додати страву , видалити страву, змінити страву, знайти страву. ");
                        break;
                }
            }
        }
        void CChangeDish()
        {
            var command = Console.ReadLine().ToLower();
            while (command != "back")
            {
                switch (command)
                {
                    case "змінити назву":
                        ChangeName();
                        break;
                    case "змінити ціну":
                        ChangePrice();
                        break;
                    case "змінити час приготування":
                        ChangeCookingTime();
                        break;

                    default:
                        Console.WriteLine("Невідома команда!");
                        break;
                }
            }
        }

        string GetLine()
        {
            var str = Console.ReadLine();
            if (str == null || str == "")
                throw new InputException("Рядок порожній!", "");
            return str;
        }

        void CPrintAllDish()
        {
            Console.WriteLine("Список страв:");
            foreach (string s in restaurant.Menu.GetDishes())
            {
                Console.WriteLine(s);
            }
        }
        void CAddDish()
        {
            try
            {
                Console.WriteLine("Введіть номер замовлення");
                int orderId = Convert.ToInt32(GetLine());

                Console.WriteLine("Введіть назву страви");
                string dishName = GetLine();

                Console.WriteLine("Введіть час приготування");
                Console.WriteLine("Дн:год:хв");
                TimeSpan cookingTime = Convert.ToDateTime(GetLine() + ":0") - new DateTime(0);

                Console.WriteLine("Введіть ціну");
                decimal price = Convert.ToDecimal(GetLine());

                restaurant.Menu.AddDish(orderId, dishName, cookingTime, price);
            }
            catch (Exception e)
            {
                Console.WriteLine("Сталася помилка!");
                Console.WriteLine(e.Message);
            }

        }

        void CRemoveDish()
        {
            try
            {

                Console.WriteLine("Введіть номер страви");
                int id = Convert.ToInt32(GetLine());

                string dish = restaurant.Menu.GetDish(id);

                Console.WriteLine("Страву видалено!" + dish);
                restaurant.Menu.RemoveDish(id);

            }
            catch (Exception e)
            {
                Console.WriteLine("Сталася помилка!");
                Console.WriteLine(e.Message);
            }
        }


        void FindDish()
        {
            try
            {
                Console.WriteLine("Введіть номер страви");
                int id = Convert.ToInt32(GetLine());

                string dish = restaurant.Menu.GetDish(id);

                Console.WriteLine(dish);

            }
            catch (Exception e)
            {
                Console.WriteLine("Сталася помилка!");
                Console.WriteLine(e.Message);
            }
        }

        void ChangeName()
        {
            try
            {
                Console.WriteLine("Введіть номер страви");
                int id = Convert.ToInt32(GetLine());

                string dish = restaurant.Menu.GetDish(id);

                Console.WriteLine(dish);

                Console.WriteLine("Введіть назву страви");
                string dishName = GetLine();
                restaurant.Menu.ChangeName(id, dishName);
            }
            catch (Exception e)
            {
                Console.WriteLine("Сталася помилка!");
                Console.WriteLine(e.Message);
            }
        }

        void ChangePrice()
        {
            try
            {
                Console.WriteLine("Введіть номер страви");
                int id = Convert.ToInt32(GetLine());

                string dish = restaurant.Menu.GetDish(id);

                Console.WriteLine(dish);

                Console.WriteLine("Введіть ціну");
                decimal price = Convert.ToDecimal(GetLine());
                restaurant.Menu.ChangePrice(id, price);
            }
            catch (Exception e)
            {
                Console.WriteLine("Сталася помилка!");
                Console.WriteLine(e.Message);
            }
        }

        void ChangeCookingTime()
        {
            try
            {
                Console.WriteLine("Введіть номер страви");
                int id = Convert.ToInt32(GetLine());

                string dish = restaurant.Menu.GetDish(id);

                Console.WriteLine(dish);

                Console.WriteLine("Введіть час приготування");
                Console.WriteLine("Дн:год:хв");
                TimeSpan cookingTime = Convert.ToDateTime(GetLine() + ":0") - new DateTime(0);

                restaurant.Menu.ChangeCookingTime(id, cookingTime);
            }
            catch (Exception e)
            {
                Console.WriteLine("Сталася помилка!");
                Console.WriteLine(e.Message);
            }
        }
    }
}
