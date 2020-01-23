namespace Portal.Cqrs.Command
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}