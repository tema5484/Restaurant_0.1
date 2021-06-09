using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_lib.BLL.Interfaces
{
    public interface IIngredients
    {
        void AddIngredient(int DishId, string ingredient);
        void RemoveIngredient( string ingredient);
        void ReplaceIngredient( string newIgredient, string ingredient);
        List<string> GetIngredients(int DishId);
        void Dispose();
    }
}
