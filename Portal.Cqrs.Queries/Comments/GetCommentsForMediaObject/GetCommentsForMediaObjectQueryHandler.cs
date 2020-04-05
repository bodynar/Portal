namespace Portal.Cqrs.Queries
{
    using System.Collections.Generic;
    using System.Linq;

    using Portal.Cqrs.Query;
    using Portal.DataAccess;
    using Portal.Entities;
    using Portal.Infrastructure;

    internal class GetCommentsForMediaObjectQueryHandler : BaseQueryHandler<GetCommentsForMediaObjectQuery, IReadOnlyCollection<Comment>>
    {
        private IRepository<Comment> Repository { get; }

        public GetCommentsForMediaObjectQueryHandler(IResolver resolver) 
            : base(resolver)
        {
            Repository = GetRepository<Comment>();
        }

        public override IReadOnlyCollection<Comment> Handle(GetCommentsForMediaObjectQuery query) 
        {
            return Repository
                .Where(new CommentSpecification.IsRelatedToMediaObject(query.MediaObjectId, query.MediaTypeId))
                .ToList();
        }
    }
}