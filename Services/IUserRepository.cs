using CommonLegacy.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLegacy.Services
{
    public interface IUserRepository
    {
        void ModifyUser(UserMod userMod);
        IEnumerable<User> GetAllUsers();
    }
}
