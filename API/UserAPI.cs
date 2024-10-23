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
            app.MapGet("/checkUser/{uid}", (FanFusionDbContext db, string uid) =>
            {
                User? userCheck = db.Users.FirstOrDefault(u => u.Uid == uid);

                if (userCheck == null)
                {
                    return Results.NotFound("User is not registered");
                }
                return Results.Ok(new
                {
                    userCheck.Id,
                    userCheck.FirstName,
                    userCheck.LastName,
                    userCheck.Email,
                    userCheck.Image,
                    userCheck.Uid
                });
            });

            //GET SINGLE USER 
            app.MapGet("/users/{userId}", (FanFusionDbContext db, int userId) =>
            {
                User? user = db.Users
                .Include(s => s.Stories)
                .Include(s => s.Chapters)
                .SingleOrDefault(u => u.Id == userId);

                if (user == null)
                {
                    return Results.NotFound($"There is no user with the following id: {userId}");
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
                    Chapters = user.Chapters?.Select(chapter => new ChapterDto(chapter))
                        .Where(chapter => chapter.SaveAsDraft == true)
                        .OrderByDescending(chapter => chapter.DateCreated),
                });
            });

        }
    }
}
