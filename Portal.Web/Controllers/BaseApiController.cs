namespace Portal.Web.Controllers
{
    using System;

    using Microsoft.AspNetCore.Mvc;

    using Portal.Cqrs.Command;
    using Portal.Cqrs.Query;
    using Portal.Infrastructure;

    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public abstract class BaseApiController : Controller
    {
        #region Private fields

        private readonly Lazy<ICommandProcessor> commandProcessor;

        private readonly Lazy<IQueryProcessor> queryProcessor;

        #endregion

        protected IResolver Resolver { get; }

        protected ICommandProcessor CommandProcessor
            => commandProcessor.Value;

        protected IQueryProcessor QueryProcessor
            => queryProcessor.Value;

        public BaseApiController(
            IResolver resolver
        )
        {
            Resolver = resolver;

            commandProcessor = new Lazy<ICommandProcessor>(Resolver.Resolve<ICommandProcessor>());
            queryProcessor = new Lazy<IQueryProcessor>(Resolver.Resolve<IQueryProcessor>());
        }
    }
}