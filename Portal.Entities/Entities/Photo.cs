namespace Portal.Entities
{
    using System.Collections.Generic;

    public class Photo : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public long AuthorId { get; set; }

        public virtual MediaType MediaType { get; set; }

        public long MediaTypeId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }

        public virtual ICollection<MediaTag> Tags { get; set; }
    }
}
