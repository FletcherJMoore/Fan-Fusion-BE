using Microsoft.EntityFrameworkCore;
using FanFusion_BE.Models;
using FanFusion_BE.Data;
namespace FanFusion_BE
{
    public class FanFusionDbContext : DbContext
    {
        public DbSet<Story> Stories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Category> Categories { get; set; }




        public FanFusionDbContext(DbContextOptions<FanFusionDbContext> context) : base(context)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Story>().HasData(StoryData.Stories);

            modelBuilder.Entity<Tag>().HasData(TagData.Tags);

            modelBuilder.Entity<User>().HasData(UserData.Users);

            modelBuilder.Entity<Chapter>().HasData(ChapterData.Chapters);

            modelBuilder.Entity<Comment>().HasData(CommentData.Comments);

            modelBuilder.Entity<Category>().HasData(CategoryData.Categories);

        }
    }
}
