using Restaurant.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Interfaces
{
    public interface IRepositoryMenu : IRepository<Menu>
    {
        public bool PutDishToMenu(int idMenu, int idDish);
        public bool LeaveDishFromMenu(int idMenu, int idDish);
        //public Menu GetMenu(int id);
    }
}
