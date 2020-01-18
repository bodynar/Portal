namespace Portal.DataAccess
{
    using Microsoft.EntityFrameworkCore;

    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}