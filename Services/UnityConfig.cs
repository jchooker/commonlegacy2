using System;
using Unity;
using Unity.WebForms;
using System.Web.Http;
using WebGrease.Configuration;
using Unity.WebApi;

namespace CommonLegacy.Services
{
    public static class UnityConfig
    {
        public static Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            //register dependencies
            container.RegisterType<UsersDbContext>();
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return Container.Value;
        }
    }
}