namespace Portal.Cqrs.Commands
{
    using Portal.Cqrs.Command;
    using Portal.DataAccess;
    using Portal.Entities;
    using Portal.Infrastructure;

    internal class AddCommentCommandHandler : BaseCommandHandler<AddCommentCommand>
    {
        private IRepository<Comment> Repository { get; }

        public AddCommentCommandHandler(IResolver resolver) 
            : base(resolver)
        {
            Repository = GetRepository<Comment>();
        }

        public override void Handle(AddCommentCommand command)
        {
            Repository.Add(
                new Comment { 
                    MediaObjectId = command.MediaObjectId,
                    Text = command.Comment,
                    ParentCommentId = command.ParentCommentId,
                    MediaTypeId = command.MediaTypeId,
                }
            );
        }
    }
}