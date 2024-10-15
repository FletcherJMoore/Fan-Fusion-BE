using FanFusion_BE;
using FanFusion_BE.Models;
namespace FanFusion_BE.Data
{
    public class StoryData
    {
        public static List<Story> Stories = new()
        {
            new()
            {
                Id = 1,
                Title = "A Second Chance at Hogwarts",
                Description = "A time-travel story where Harry returns to his first year to fix everything.",
                Image = "https://example.com/images/hogwarts.jpg",
                DateCreated = new DateTime(2024, 10, 01),
                TargetAudience = "Young Adult",
                UserUID = "user123",
                CategoryId = "3" // Fantasy
            },
            new()
            {
                Id = 2,
                Title = "Galactic Refuge",
                Description = "Two rival bounty hunters must work together to survive an intergalactic chase.",
                Image = "https://example.com/images/galactic.jpg",
                DateCreated = new DateTime(2024, 09, 28),
                TargetAudience = "New Adult",
                UserUID = "user456",
                CategoryId = "4" // Science Fiction
            },
            new()
            {
                Id = 3,
                Title = "Heartstrings",
                Description = "A romance between a concert violinist and the mysterious pianist next door.",
                Image = "https://example.com/images/heartstrings.jpg",
                DateCreated = new DateTime(2024, 10, 05),
                TargetAudience = "Adult",
                UserUID = "user789",
                CategoryId = "1" // Romance
            },
            new()
            {
                Id = 4,
                Title = "The Laughing Detective",
                Description = "A detective with a love for pranks solves cases with humor.",
                Image = "https://example.com/images/detective.jpg",
                DateCreated = new DateTime(2024, 10, 07),
                TargetAudience = "Young Adult",
                UserUID = "user234",
                CategoryId = "11" // Humor
            },
            new()
            {
                Id = 5,
                Title = "Castle of Shadows",
                Description = "An exiled prince returns to reclaim his haunted castle.",
                Image = "https://example.com/images/castle.jpg",
                DateCreated = new DateTime(2024, 10, 12),
                TargetAudience = "New Adult",
                UserUID = "user567",
                CategoryId = "7" // Supernatural
            },
            new()
            {
                Id = 6,
                Title = "Into the Abyss",
                Description = "A group of teenagers discovers a portal to a parallel world.",
                Image = "https://example.com/images/abyss.jpg",
                DateCreated = new DateTime(2024, 09, 15),
                TargetAudience = "Young Adult",
                UserUID = "user890",
                CategoryId = "4" // Science Fiction
            },
            new()
            {
                Id = 7,
                Title = "Café Encounters",
                Description = "A series of heartwarming meetings at a small-town coffee shop.",
                Image = "https://example.com/images/cafe.jpg",
                DateCreated = new DateTime(2024, 09, 22),
                TargetAudience = "Adult",
                UserUID = "user001",
                CategoryId = "8" // Slice of Life
            },
            new()
            {
                Id = 8,
                Title = "Whispers in the Dark",
                Description = "A ghost helps a troubled author find peace through her writing.",
                Image = "https://example.com/images/whispers.jpg",
                DateCreated = new DateTime(2024, 10, 02),
                TargetAudience = "New Adult",
                UserUID = "user002",
                CategoryId = "7" // Supernatural
            },
            new()
            {
                Id = 9,
                Title = "Heroes and Villains",
                Description = "A villain falls in love with the hero sworn to defeat them.",
                Image = "https://example.com/images/heroes.jpg",
                DateCreated = new DateTime(2024, 09, 30),
                TargetAudience = "Young Adult",
                UserUID = "user003",
                CategoryId = "14" // Crossover
            },
            new()
            {
                Id = 10,
                Title = "Letters from the Past",
                Description = "Old letters reveal a forgotten love story between two soldiers.",
                Image = "https://example.com/images/letters.jpg",
                DateCreated = new DateTime(2024, 09, 18),
                TargetAudience = "Adult",
                UserUID = "user004",
                CategoryId = "10" // Historical Fiction
            },
            new()
            {
                Id = 11,
                Title = "The Last Stand",
                Description = "A warrior prepares for a final battle, haunted by visions of the future.",
                Image = "https://example.com/images/stand.jpg",
                DateCreated = new DateTime(2024, 10, 08),
                TargetAudience = "New Adult",
                UserUID = "user005",
                CategoryId = "3" // Fantasy
            },
            new()
            {
                Id = 12,
                Title = "Comedy of Errors",
                Description = "A mix-up at a royal wedding leads to a cascade of hilarious events.",
                Image = "https://example.com/images/comedy.jpg",
                DateCreated = new DateTime(2024, 10, 04),
                TargetAudience = "Young Adult",
                UserUID = "user006",
                CategoryId = "11" // Humor
            },
            new()
            {
                Id = 13,
                Title = "Between the Lines",
                Description = "Two writers leave coded messages for each other in their novels.",
                Image = "https://example.com/images/lines.jpg",
                DateCreated = new DateTime(2024, 09, 25),
                TargetAudience = "Adult",
                UserUID = "user007",
                CategoryId = "12" // Drama
            },
            new()
            {
                Id = 14,
                Title = "The Midnight Express",
                Description = "A secret train only appears to those in need of second chances.",
                Image = "https://example.com/images/express.jpg",
                DateCreated = new DateTime(2024, 10, 03),
                TargetAudience = "Young Adult",
                UserUID = "user008",
                CategoryId = "7" // Supernatural
            },
            new()
            {
                Id = 15,
                Title = "Parallel Paths",
                Description = "A scientist and an artist explore love across multiple dimensions.",
                Image = "https://example.com/images/paths.jpg",
                DateCreated = new DateTime(2024, 09, 20),
                TargetAudience = "New Adult",
                UserUID = "user009",
                CategoryId = "4" // Science Fiction
            }
        };

    }
}