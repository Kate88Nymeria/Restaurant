using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public List<Dish> Dishes { get; set; }
    }
}
