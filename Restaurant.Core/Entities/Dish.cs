using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        public string DishName { get; set; }
        public DishType DishType { get; set; }
        public decimal Price { get; set; }
        public int MenuID { get; set; }
        public Menu Menu { get; set; }
    }

    public enum DishType
    {
        First,
        Second,
        Side,
        Dessert
    }
}
