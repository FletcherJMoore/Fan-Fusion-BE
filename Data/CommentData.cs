using FanFusion_BE.Models;

namespace FanFusion_BE.Data
{
    public class CommentData
    {
        public static List<Comment> Comments = new()
    {
        new()
        {
            Id = 1,
            Content = "I love the twist on Harry's choices! It really makes me think about fate.",
            CreatedOn = new DateTime(2024, 10, 02),
            UserId = 14,
            ChapterId = 1
        },
        new()
        {
            Id = 2,
            Content = "Vera and Jax have such great chemistry! Can't wait to see what happens next.",
            CreatedOn = new DateTime(2024, 10, 01),
            UserId = 13,
            ChapterId = 2
        },
        new()
        {
            Id = 3,
            Content = "The suspense in this chapter is intense! What will Emma do next?",
            CreatedOn = new DateTime(2024, 10, 06),
            UserId = 11,
            ChapterId = 3
        },
        new()
        {
            Id = 4,
            Content = "This mystery is captivating! I can't believe the spoon was hiding jewels!",
            CreatedOn = new DateTime(2024, 10, 08),
            UserId = 10,
            ChapterId = 4
        },
        new()
        {
            Id = 5,
            Content = "Aldric's struggle with the throne is fascinating! Will he choose power or redemption?",
            CreatedOn = new DateTime(2024, 10, 13),
            UserId = 15,
            ChapterId = 5
        },
        new()
        {
            Id = 6,
            Content = "Emily's journey through the abyss sounds incredible! I hope she finds her way back.",
            CreatedOn = new DateTime(2024, 10, 03),
            UserId = 12,
            ChapterId = 6
        },
        new()
        {
            Id = 7,
            Content = "Amara and Theo's reunion gives me all the feels! Can't wait for more.",
            CreatedOn = new DateTime(2024, 10, 11),
            UserId = 10,
            ChapterId = 7
        },
        new()
        {
            Id = 8,
            Content = "Nina's last performance is heartbreaking! What a way to say goodbye.",
            CreatedOn = new DateTime(2024, 10, 13),
            UserId = 14,
            ChapterId = 8
        },
        new()
        {
            Id = 9,
            Content = "Max's dilemma in the corporate world is so relatable! What a tough choice.",
            CreatedOn = new DateTime(2024, 10, 04),
            UserId = 13,
            ChapterId = 9
        },
        new()
        {
            Id = 10,
            Content = "Dr. Monroe's story is inspiring! Healing goes beyond just physical health.",
            CreatedOn = new DateTime(2024, 10, 05),
            UserId = 15,
            ChapterId = 10
        },
        new()
        {
            Id = 11,
            Content = "Leo's adventure sounds exhilarating! Can't wait to see where it takes him.",
            CreatedOn = new DateTime(2024, 10, 10),
            UserId = 11,
            ChapterId = 11
        },
        new()
        {
            Id = 12,
            Content = "Senator Quinn's struggles with power are gripping! This story has me on edge.",
            CreatedOn = new DateTime(2024, 10, 02),
            UserId = 12,
            ChapterId = 12
        },
        new()
        {
            Id = 13,
            Content = "Jade's victory is so empowering! Love this journey of self-discovery.",
            CreatedOn = new DateTime(2024, 10, 06),
            UserId = 10,
            ChapterId = 13
        },
        new()
        {
            Id = 14,
            Content = "The festival's cultural richness is beautifully portrayed! Great family bonding.",
            CreatedOn = new DateTime(2024, 10, 02),
            UserId = 15,
            ChapterId = 14
        }
    };
    }
}
