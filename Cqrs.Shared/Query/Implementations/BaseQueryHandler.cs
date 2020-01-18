namespace Portal.Cqrs.Query
{
    using System;

    using Portal.Cqrs.Command;
    using Portal.DataAccess;
    using Portal.Entites;
    using Portal.Infrastructure;

    internal abstract class BaseQueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        #region Private fields

        private Lazy<IQueryProcessor> _queryProcessor
            => new Lazy<IQueryProcessor>(Resolver.Resolve<IQueryProcessor>);

        private Lazy<ICommandProcessor> _commandProcessor
            => new Lazy<ICommandProcessor>(Resolver.Resolve<ICommandProcessor>);

        #endregion

        protected IResolver Resolver { get; }

        protected IQueryProcessor QueryProcessor
            => _queryProcessor.Value;

        protected ICommandProcessor CommandProcessor
            => _commandProcessor.Value;

        public BaseQueryHandler(
            IResolver resolver
        )
        {
            Resolver = resolver;
        }

        public abstract TResult Handle(TQuery query);

        protected IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : Entity
        {
            return Resolver.Resolve<IRepository<TEntity>>();
        }
    }
}