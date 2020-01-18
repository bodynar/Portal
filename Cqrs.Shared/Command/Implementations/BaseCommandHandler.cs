namespace Portal.Cqrs.Command
{
    using System;

    using Portal.Cqrs.Query;
    using Portal.DataAccess;
    using Portal.Entites;
    using Portal.Infrastructure;

    internal abstract class BaseCommandHandler<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
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

        public BaseCommandHandler(
            IResolver resolver
        )
        {
            Resolver = resolver;
        }

        public abstract void Handle(TCommand command);

        protected IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : Entity
        {
            return Resolver.Resolve<IRepository<TEntity>>();
        }

        protected IUnitOfWork CreateUnitOfWorkScope()
        {
            return Resolver.Resolve<IUnitOfWork>();
        }
    }
}