using OnlineStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DataAccess.Abstract
{
    public interface IUserRepository
    {
        User CreateUser(User user);

        User GetUserByUsername(string username);

        User GetUserById(Guid id);
    }
}
