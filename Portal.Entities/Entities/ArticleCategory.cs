namespace Portal.Entities
{
    using System.Collections.Generic;

    public class ArticleCategory : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ArticleCategory ParentCategory { get; set; }

        public long? ParentCategoryId { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}