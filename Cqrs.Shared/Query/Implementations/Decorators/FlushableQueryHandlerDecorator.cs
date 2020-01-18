namespace Portal.Cqrs.Query
{
    using Portal.DataAccess;
    using Portal.Infrastructure;

    public class FlushableQueryHandlerDecorator<TQuery, TResult> : BaseQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        private readonly IQueryHandler<TQuery, TResult> decorated;

        public FlushableQueryHandlerDecorator(
            IQueryHandler<TQuery, TResult> decorated,
            IResolver resolver
        ) : base(resolver)
        {
            this.decorated = decorated;
        }

        public override TResult Handle(TQuery query)
        {
            TResult result;

            using (var scope = CreateUnitOfWorkScope())
            {
                result = this.decorated.Handle(query);
            }

            return result;
        }

        private IUnitOfWork CreateUnitOfWorkScope()
        {
            return Resolver.Resolve<IUnitOfWork>();
        }
    }
}