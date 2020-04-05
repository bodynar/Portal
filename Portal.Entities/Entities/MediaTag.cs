namespace Portal.Entities
{
    public class MediaTag : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual MediaType MediaType { get; set; }

        public long MediaTypeId { get; set; }

        public long MediaObjectId { get; set; }
    }
}