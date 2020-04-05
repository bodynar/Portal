namespace Portal.Entities
{
    public class Feedback: Entity
    {
        public bool IsPositive { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public string AuthorId { get; set; }

        public virtual MediaType MediaType { get; set; }

        public long MediaTypeId { get; set; }

        public long MediaObjectId { get; set; }
    }
}