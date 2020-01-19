namespace Portal.Entities
{
    using System.Collections.Generic;

    public partial class Department : Entity 
    {
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}