using System;

namespace Portal.Entities
{
    public class Comment: Entity
    {
        public string Text { get; set; }

        public DateTime Date { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public string AuthorId { get; set; }

        public virtual Article Article { get; set; }

        public virtual Video Video { get; set; }

        public virtual Photo Photo { get; set; }

        public virtual PhotoAlbum PhotoAlbum { get; set; }
    }
}