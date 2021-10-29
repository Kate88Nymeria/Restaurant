using Restaurant.Core.Entities;
using Restaurant.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.EF.Repositories
{
    public class RepositoryUserEF : IRepositoryUser
    {
        private readonly RestaurantContext ctx;
        public RepositoryUserEF(RestaurantContext context)
        {
            ctx = context;
        }

        public bool AddItem(User item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Fetch(Func<User, bool> filter = null)
        {
            throw new NotImplementedException();
        }

        public User GetByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return null;

            return ctx.Users.FirstOrDefault(u => u.Email.Equals(email));
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItem(User item)
        {
            throw new NotImplementedException();
        }
    }
}
