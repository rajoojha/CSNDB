using System.Web.Mvc;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using System.Collections.Generic;
namespace CSN.Web
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {

            UnityContainer container = new UnityContainer();
            container.RegisterTypes(
                AllClasses.FromLoadedAssemblies().Where(t => t.Namespace != null && t.Namespace.Contains("CSN.Business")),
                         WithMappings.FromMatchingInterface,
                        WithName.Default //,
                //WithLifetime.ContainerControlled
                        );


            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();           

            return container;
        }
    }
}