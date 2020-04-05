namespace Portal.Cqrs.Queries
{
    using System.Collections.Generic;

    using Portal.Cqrs.Query;
    using Portal.Entities;

    public class GetCommentsForMediaObjectQuery: IQuery<IReadOnlyCollection<Comment>>
    {
        public long MediaTypeId { get; set; }

        public long MediaObjectId { get; set; }
    }
}