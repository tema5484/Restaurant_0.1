using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_lib.DAL.Entity
{
    public class Ingredient
    {
        public int Id;
        public string Name;
        public virtual Dish Dish { get; set; }
    }
}
