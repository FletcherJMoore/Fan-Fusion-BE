using FanFusion_BE.Models;

namespace FanFusion_BE.API
{
    public class CommentAPI
    {
        public static void Map(WebApplication app)
        {

            app.MapPost("/comments", (FanFusionDbContext db, Comment newComment) =>
            {
                if (!db.Users.Any(user => user.Id == newComment.UserId))
                {
                    return Results.NotFound($"There is no user with the following id: {newComment.UserId}");
                }
                else if (!db.Chapters.Any(chapter => chapter.Id == newComment.ChapterId))
                {
                    return Results.NotFound($"There are no chapters with the following id: {newComment.ChapterId}");
                }

                Comment comment = new()
                {
                    Content = newComment.Content,
                    CreatedOn = DateTime.Now,
                    UserId = newComment.UserId,
                    ChapterId = newComment.ChapterId,
                };

                db.Comments.Add(comment);
                db.SaveChanges();
                return Results.Ok(comment);
            });

            app.MapDelete("/comments/{commentId}", (FanFusionDbContext db, int commmentId) =>
            {
                Comment commentToDelete = db.Comments.SingleOrDefault(comment => comment.Id == commmentId);

                if (commentToDelete == null)
                {
                    return Results.NotFound($"There is no comment with a matching id of: {commmentId}");
                }

                db.Comments.Remove(commentToDelete);
                db.SaveChanges();
                return Results.Ok(commentToDelete);
            });
        }
    }
}
