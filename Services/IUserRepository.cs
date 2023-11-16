using CommonLegacy.entities;
using System.Collections.Generic;

namespace CommonLegacy.Services
{
    public interface IUserRepository
    {
        void ModifyUser(UserMod userMod);
        IEnumerable<User> GetAllUsers();
        int AddUser(User user);
        bool DeleteUser(int userDel);
    }
}
