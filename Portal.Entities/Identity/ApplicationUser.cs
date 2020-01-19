namespace Portal.Entities
{
    using System;

    public class ApplicationUser
    {
        public DateTime RegisterDate { get; set; }

        public virtual Employee Employee { get; set; }

        public long Id { get; set; }

        public bool HasTemporaryPassword { get; set; }
    }
}