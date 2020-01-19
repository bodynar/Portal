namespace Portal.Entities
{
    using System.Collections.Generic;

    public class VideoCategory: Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual VideoCategory ParentCategory { get; set; }

        public long? ParentCategoryId { get; set; }

        public virtual ICollection<Video> Videos { get; set; }
    }
}