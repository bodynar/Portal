namespace Portal.Cqrs.Commands
{
    using Portal.Cqrs.Command;

    public class AddCommentCommand : ICommand
    {
        public long MediaTypeId { get; set; }

        public long MediaObjectId { get; set; }

        public string Comment { get; set; }

        public long? ParentCommentId { get; set; }
    }
}