using System;

namespace Portal.Infrastructure
{
    public interface IResolver
    {
        TService Resolve<TService>()
            where TService : class;

        object GetInstance(Type serviceType);
    }
}
