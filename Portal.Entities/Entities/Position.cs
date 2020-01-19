namespace Portal.Entities
{
    using System.Collections.Generic;

    public class Position: Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}