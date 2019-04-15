using Newsletter.Repositories;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Newsletter
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<ISubscriptionRepository, SubscriptionRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}