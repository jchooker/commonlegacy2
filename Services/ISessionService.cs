using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLegacy.Services
{
    public interface ISessionService
    {
        Task<string> GetSessionValueAsync(string key);
        //Task SetSessionValueAsync(string key, string value);
    }
}
