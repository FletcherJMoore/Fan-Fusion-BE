using FanFusion_BE.Models;

namespace FanFusion_BE.Data
{
    public class CategoryData
    {
        public static List<Category> Categories = new()
        {
            new() { Id = 1, Title = "Romance" },
            new() { Id = 2, Title = "Adventure" },
            new() { Id = 3, Title = "Fantasy" },
            new() { Id = 4, Title = "Science Fiction" },
            new() { Id = 5, Title = "Mystery" },
            new() { Id = 6, Title = "Thriller" },
            new() { Id = 7, Title = "Supernatural" },
            new() { Id = 8, Title = "Slice of Life" },
            new() { Id = 9, Title = "Horror" },
            new() { Id = 10, Title = "Historical Fiction" },
            new() { Id = 11, Title = "Humor" },
            new() { Id = 12, Title = "Drama" },
            new() { Id = 13, Title = "Fanfiction" },
            new() { Id = 14, Title = "Crossover" },
            new() { Id = 15, Title = "Fluff" }
        };
    }
}
