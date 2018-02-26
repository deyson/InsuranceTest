using InsurancePolicy.Core.Interfaces;
using InsurancePolicy.Infrastructure.Repositories;
using System.Web.Http;
using Unity;


namespace InsurancePolicy.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IInsuranceRepository, InsuranceRepository>();
            container.RegisterType<IRequestRepository, RequestRepository>();


            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
            
        }
    }
}