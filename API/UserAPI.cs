using FanFusion_BE.DTO;
using FanFusion_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace FanFusion_BE.API
{
    public class UserAPI
    {
        public static void Map(WebApplication app)
        {
            //GET SINGLE STORY AND IT'S CHAPTERS
            app.MapGet("/users/{userId}", (FanFusionDbContext db, int userId) =>
            {
                User? user = db.Users
                .Include(s => s.Stories)
                .SingleOrDefault(u => u.Id == userId);

                if (user == null)
                {
                    return Results.NotFound("User not found");
                }

                return Results.Ok(new
                {
                    user.Id,
                    user.FirstName,
                    user.LastName,
                    user.Image,
                    user.Username,
                    user.Uid,
                    Stories = user.Stories?.Select(story => new StoryDTO(story)).ToList(),
                });
            });

        }
    }
}
