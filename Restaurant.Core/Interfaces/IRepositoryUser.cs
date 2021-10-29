using Restaurant.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Interfaces
{
    public interface IRepositoryUser : IRepository<User>
    {
        User GetByEmail(string email);
    }
}
