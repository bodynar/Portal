namespace Portal.Entities
{
    using System;
    using System.Collections.Generic;

    public class Video: Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public TimeSpan Duration { get; set; }

        //public bool IsConverted { get; set; }

        public bool IsReady { get; set; }

        public string Path { get; set; }

        public DateTime UploadingDate { get; set; }

        public string Preview { get; set; }

        public int Views { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public string AuthorId { get; set; }

        public virtual VideoCategory Category { get; set; }

        public long? CategoryId { get; set; }

        public virtual MediaType MediaType { get; set; }

        public long MediaTypeId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }

        public virtual ICollection<MediaTag> MediaTags { get; set; }
    }
}