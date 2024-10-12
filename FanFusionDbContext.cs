using Microsoft.EntityFrameworkCore;
using FanFusion_BE.Models;
namespace FanFusion_BE
{
    public class FanFusionDbContext : DbContext
    {
        public DbSet<Story> Stories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }


        public FanFusionDbContext(DbContextOptions<FanFusionDbContext> context) : base(context)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Story>().HasData(StoryData.Stories);

            modelBuilder.Entity<Tag>().HasData(TagData.Tags);

            modelBuilder.Entity<User>().HasData(UserData.Users);

        }
    }
}
