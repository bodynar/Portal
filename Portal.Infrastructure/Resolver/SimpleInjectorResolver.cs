using SimpleInjector;

using System;

namespace Portal.Infrastructure
{
    internal class SimpleInjectorResolver : IResolver
    {
        private Container Container { get; }

        public SimpleInjectorResolver(Container container)
        {
            Container = container;
        }

        public TService Resolve<TService>()
            where TService : class
        {
            return Container.GetInstance<TService>();
        }

        public object GetInstance(Type serviceType)
        {
            return Container.GetInstance(serviceType);
        }
    }
}
