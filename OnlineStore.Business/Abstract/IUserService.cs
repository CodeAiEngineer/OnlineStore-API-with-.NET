using OnlineStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Business.Abstract
{
    public interface IUserService
    {
        User CreateUser(User user);

        User GetUserByUsername(string username);

        User GetUserById(Guid id);

        AuthData Login(LoginRequest loginRequest);
    }
}
