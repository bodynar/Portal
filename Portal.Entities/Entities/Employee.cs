namespace Portal.Entities
{
    using System;

    public class Employee: Entity
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }

        public byte[] Photo { get; set; }

        public byte[] PreviewPhoto { get; set; }

        public bool IsFired { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual Position Position { get; set; }

        public long? PositionId { get; set; }

        public virtual Department Department { get; set; }

        public long? DepartmentId { get; set; }
    }
}