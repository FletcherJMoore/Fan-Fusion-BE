using FanFusion_BE.DTO;
using FanFusion_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace FanFusion_BE.API
{
    public class UserAPI
    {
        public static void Map(WebApplication app)
        {
            //CHECK USER
          /*  app.MapPost("/checkUser", (FanFusionDbContext db, string userId) =>
            {
                var user = db.Users
                  .Where(u => u.Uid == userId)
                  .FirstOrDefault();

                if (user == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(user);
            });*/

            //GET SINGLE STORY AND IT'S STORIES
            app.MapGet("/users/{userId}", (FanFusionDbContext db, string userId) =>
            {
                User? user = db.Users
                .Include(s => s.Stories)
                .SingleOrDefault(u => u.Uid == userId);

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
