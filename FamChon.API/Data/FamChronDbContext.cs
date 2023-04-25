using FamChron.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace FamChron.API.Data
{
    public class FamChronDbContext : DbContext
    {
        public FamChronDbContext(DbContextOptions<FamChronDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stories>().HasData(new Stories
            {
                id = 1,
                Name = "The Beginning"
            });
            modelBuilder.Entity<Events>().HasData(new Events
            {
                id = 1,
                Name ="First step",
                Date = DateTime.UtcNow,
                Description = "wOw",
                PreviewPhoto = "None",
                Photos = "None",
                StoryID = 1,
            });
            modelBuilder.Entity<Characters>().HasData(new Characters
            {
                id = 1,
                Name = "Coffee",
                Description = "I love coffee",
                StoryID = 1,
                EventID = 1
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                id = 1,
                UserName = "Lubimec"
            });
        }

        public DbSet<Characters> Characters { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Stories> Stories { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
