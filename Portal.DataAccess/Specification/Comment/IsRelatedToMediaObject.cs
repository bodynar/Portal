namespace Portal.DataAccess
{
    using System;
    using System.Linq.Expressions;

    using Portal.Entities;

    public static class CommentSpecification
    {
        public sealed class IsRelatedToMediaObject : Specification<Comment>
        {
            public long MediaObjectId { get; }

            public long MediaTypeId { get; }

            public IsRelatedToMediaObject(long mediaObjectId, long mediaTypeId)
            {
                MediaObjectId = mediaObjectId;
                MediaTypeId = mediaTypeId;
            }

            public override Expression<Func<Comment, bool>> IsSatisfied()
                => comment => comment.MediaObjectId == MediaObjectId && comment.MediaTypeId == MediaTypeId;
        }
    }
}