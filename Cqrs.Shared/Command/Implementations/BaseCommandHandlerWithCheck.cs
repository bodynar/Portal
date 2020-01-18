namespace Portal.Cqrs.Command.Implementations
{
    using Portal.Cqrs.Query;
    using Portal.Infrastructure;

    internal abstract class BaseCommandHandlerWithCheck<TCommand> : BaseCommandHandler<TCommand>
        where TCommand : ICommand
    {
        public BaseCommandHandlerWithCheck(
            IResolver resolver
        ) : base(resolver)
        {
        }

        public abstract CheckResult Check(TCommand command);

        public override void Handle(TCommand command)
        {
            var checkResult = Check(command);

            if (checkResult.IsSuccess)
            {
                HandleChecked(command);
            }
            else
            {
                throw new CommandExecutionException(checkResult.ErrorMessage);
            }
        }

        /// <summary>
        /// Handle command after successful check
        /// </summary>
        public abstract void HandleChecked(TCommand command);
    }
}