using MASGlobal.HandsOn.Business.Providers;
using MASGlobal.HandsOn.Business.Providers.Contracts;
using MASGlobal.HandsOn.Repository;
using MASGlobal.HandsOn.Repository.Contracts;
using MASGlobal.HandsOn.Tool.Web;
using MASGlobal.HandsOn.Website.IoC;
using System.Web.Http;
using Unity;

namespace MASGlobal.HandsOn.Website
{
    public static class UnityConfig
    {
        public static void RegisterComponents(HttpConfiguration config)
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IWebRequest, WebRequest>();
            container.RegisterType<IEmployeesRepository, EmployeesRepository>();
            container.RegisterType<IEmployeesProvider, EmployeesProvider>();
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}