using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace CommonLegacy.Services
{
    public class HttpSessionService : ISessionService
    {
        public async Task<string> GetSessionValueAsync(string key)
        {
            if (HttpContext.Current.Session != null)
            {
                return await Task.Run(() => HttpContext.Current.Session[key] as string);
            }
            return null;
        }

        public async Task SetSessionValueAsync(string key, string value)
        {
            if (HttpContext.Current.Session != null)
            {
                await Task.Run(() => HttpContext.Current.Session[key] = value);
            }
        }
    }
}