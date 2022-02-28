using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Agents;
using System.Web.Http;
using Unity.AspNet.Mvc;
using UnityDependencyResolver = Unity.Mvc5.UnityDependencyResolver;
using System;

namespace ContactPOC
{
    public static class UnityConfig
    {
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });
        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        public static void RegisterTypes(IUnityContainer container)
        {
			//var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            
            container.RegisterType<IContactAgent, ContactAgent>(new PerRequestLifetimeManager());


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            
        }
    }
}