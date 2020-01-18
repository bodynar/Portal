namespace Portal.Cqrs.Command
{
    public interface ICommandProcessor
    {
        void Execute<TCommand>(TCommand command)
            where TCommand : ICommand;
    }
}