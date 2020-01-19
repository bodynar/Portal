namespace Portal.Bootstrap
{
    using Portal.Cqrs.Command;
    using Portal.Cqrs.Query;
    using Portal.DataAccess;
    using Portal.Infrastructure;

    using SimpleInjector;

    public static class Bootstraper
    {
        //// <para>
        //// Custom dependency container configuration
        //// </para>
        public static void Configure(this Container container)
        {
            #region CQRS

            container.Register(
                typeof(IQueryHandler<,>),
                typeof(IQueryHandler<,>).Assembly);

            container.RegisterDecorator(
                typeof(IQueryHandler<,>),
                typeof(FlushableQueryHandlerDecorator<,>));

            container.Register(
                typeof(ICommandHandler<>),
                typeof(ICommandHandler<>).Assembly);

            container.RegisterDecorator(
                typeof(ICommandHandler<>),
                typeof(TransactionCommandHandlerDecorator<>));

            container.Register(typeof(IQueryProcessor), typeof(QueryProcessor), Lifestyle.Singleton);
            container.Register(typeof(ICommandProcessor), typeof(CommandProcessor), Lifestyle.Singleton);

            #endregion

            #region Database

            //container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            //container.Register(typeof(IRepository<>), typeof(Repository<>));

            #endregion

            container.Register(typeof(IResolver), typeof(SimpleInjectorResolver), Lifestyle.Singleton);
        }
    }
}
