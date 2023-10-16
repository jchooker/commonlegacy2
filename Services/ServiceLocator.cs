using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CommonLegacy.Services
{
    public class ServiceLocator
    {
        public static IUserRepository GetUserRepository()
        {
            return new UserRepository();
        }
    }
}