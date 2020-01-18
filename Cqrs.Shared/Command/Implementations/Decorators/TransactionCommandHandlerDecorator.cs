namespace Portal.Cqrs.Command
{
    using Portal.Infrastructure;

    public class TransactionCommandHandlerDecorator<TCommand> : BaseCommandHandler<TCommand>
        where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> decorated;

        public TransactionCommandHandlerDecorator(
            ICommandHandler<TCommand> decorated,
            IResolver resolver
        ) : base(resolver)
        {
            this.decorated = decorated;
        }

        public override void Handle(TCommand command)
        {
            using (var scope = CreateUnitOfWorkScope())
            {
                this.decorated.Handle(command);

                scope.Commit();
            }
        }
    }
}
