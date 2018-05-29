using BroadbandDeals.Service.IServiceContracts;
using BroadbandDeals.Service.ServiceContracts;
using System.Web.Http;
using Unity;
using Unity.WebApi;
using Unity.Injection;

namespace BroadbandDeals.Service
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IUtilityService, UtilityService>();

            container.RegisterType<IBroadbandService, BroadbandService>(new InjectionConstructor(new ResolvedParameter<IUtilityService>()));
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}