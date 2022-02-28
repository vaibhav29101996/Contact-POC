using Services;
using Services.Repository;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace ContactAPIPOC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IContactService, ContactService>();

            container.RegisterType(typeof(IContactRepository<>), typeof(ContactRepository<>));



            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

        }
    }
}