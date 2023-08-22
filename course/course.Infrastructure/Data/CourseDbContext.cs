using course.Entities;
using Microsoft.EntityFrameworkCore;

namespace course.Infrastructure.Data
{
    public class CourseDbContext : DbContext
    {

        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().Property(c => c.Title).IsRequired()
                                                                .HasMaxLength(350);

            modelBuilder.Entity<Course>().HasOne(course => course.Category)
                                         .WithMany(category => category.Courses)
                                         .HasForeignKey(course => course.CategoryId)
                                         .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Category>().HasData(
                  new Category { Id = 1, Name = "Development" },
                  new Category { Id = 2, Name = "Art" },
                  new Category { Id = 3, Name = "Language" }
                );

            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    Id = 1,
                    Title = "Temel ASP.NET Core",
                    CategoryId = 1,
                    Description = "ASP.NET Core ile web geliştirmeyi öğrenin",
                    Duration = 200,
                    ImageUrl = "https://placehold.co/300x200"
                },
                 new Course { Id = 2, Title = "İleri ASP.NET Core", CategoryId = 1, Description = "ASP.NET Core ile web geliştirmeyi öğrenin", Duration = 200, ImageUrl = "https://placehold.co/300x200" },
                  new Course { Id = 3, Title = "Resim", CategoryId = 2, Description = "Güzel sanatlar...", Duration = 200, ImageUrl = "https://placehold.co/300x200" },
                   new Course { Id = 4, Title = "İngilizce", CategoryId = 3, Description = "İngilizce", Duration = 200, ImageUrl = "https://placehold.co/300x200" },
                    new Course { Id = 5, Title = "Fransızca", CategoryId = 3, Description = "Fransızca", Duration = 200, ImageUrl = "https://placehold.co/300x200" }


                );

        }
    }
}
