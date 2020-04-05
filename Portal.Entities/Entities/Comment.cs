using System;

namespace Portal.Entities
{
    public class Comment: Entity
    {
        public string Text { get; set; }

        public DateTime Date { get; set; }

        public bool IsBlocked { get; set; }

        public virtual ApplicationUser BlockedBy { get; set; }

        public long? BlockedById { get; set; }

        public virtual Comment ParentComment { get; set; }

        public long? ParentCommentId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public string AuthorId { get; set; }

        public virtual MediaType MediaType { get; set; }

        public long MediaTypeId { get; set; }

        public long MediaObjectId { get; set; }
    }
}