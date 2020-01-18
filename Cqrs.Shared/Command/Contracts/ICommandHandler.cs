namespace Portal.Cqrs.Command
{
    internal interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}