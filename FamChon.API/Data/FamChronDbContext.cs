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
            modelBuilder.Entity<Story>().HasData(new Story
            {
                id = 1,
                Name = "The Beginning"
            });
            modelBuilder.Entity<Event>().HasData(new Event
            {
                id = 1,
                Name ="First step",
                Date = DateTime.UtcNow,
                Description = "wOw",
                PreviewPhoto = "None",
                Photos = "None",
                StoryID = 1,
            });
            modelBuilder.Entity<Character>().HasData(new Character
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
            modelBuilder.Entity<TimeLine>().HasData(new TimeLine
            {
                Id = 1,
                StoryId = 1,
                EventsIds = 1
            });
        }
         
        public DbSet<Character> Characters { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TimeLine> TileLines { get; set; }

    }
}
