namespace Portal.Entities
{
    using System.Collections.Generic;

    public class ApplicationRole : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}