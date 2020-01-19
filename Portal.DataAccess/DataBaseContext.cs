namespace Portal.DataAccess
{
    using Microsoft.EntityFrameworkCore;

    using Portal.Entities;

    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        { }

        public DbSet<Article> Articles { get; set; }

        public DbSet<ArticleCategory> ArticleCategories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<MediaType> MediaTypes { get; set; }

        public DbSet<MediaTag> MediaTags { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<PhotoAlbum> PhotoAlbums { get; set; }

        public DbSet<Video> Videos { get; set; }

        public DbSet<VideoCategory> VideoCategories { get; set; }

        public DbSet<ApplicationUser> Users { get; set; }

        public DbSet<ApplicationRole> ApplicationRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MediaTag>()
                .Property(b => b.MediaTypeId)
                .IsRequired();

            modelBuilder.Entity<Video>()
               .Property(b => b.MediaTypeId)
               .HasDefaultValue<long>(1);

            modelBuilder.Entity<Article>()
                .Property(b => b.MediaTypeId)
                .HasDefaultValue<long>(2);

            modelBuilder.Entity<PhotoAlbum>()
                .Property(b => b.MediaTypeId)
                .HasDefaultValue<long>(3);

            modelBuilder.Entity<Photo>()
                .Property(b => b.MediaTypeId)
                .HasDefaultValue<long>(4);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(b => b.Employee)
                .WithOne()
                .HasForeignKey<ApplicationUser>(b => b.Id);

            modelBuilder
                .Entity<MediaType>()
                .HasData(
                    new MediaType { Id = 1, Name = "Video", Description = "Video file uploaded by someone" },
                    new MediaType { Id = 2, Name = "Article", Description = "Article wrotten by someone" },
                    new MediaType { Id = 3, Name = "PhotoAlbum", Description = "Stack of pics published by someone" },
                    new MediaType { Id = 4, Name = "Photo", Description = "Photo published by someone" }
                );
        }
    }
}