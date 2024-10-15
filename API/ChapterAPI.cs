using FanFusion_BE.DTO;
using FanFusion_BE.Models;
using Microsoft.EntityFrameworkCore;
using Rare.Models;


namespace FanFusion_BE.API
{
    public class ChapterAPI
    {
        public static void Map(WebApplication app)
        {
            //Get Single 
            app.MapGet("/chapters/{chapterId}", (FanFusionDbContext db, int chapterId) =>
            {
                Chapter chapter = db.Chapters
                .Include(ch => ch.Story)
                .Include(ch => ch.User)
                .Include(ch => ch.Comments)
                .ThenInclude(comment => comment.User)
                .SingleOrDefault(ch => ch.Id == chapterId);

                if (chapter == null)
                {
                    return Results.NotFound($"No chapter was found with the following id: {chapterId}");
                }

                return Results.Ok(new
                {
                    chapter.Id,
                    chapter.Title,
                    chapter.Content,
                    chapter.DateCreated,
                    chapter.SaveAsDraft,
                    Story = new
                    {
                        chapter.Story.Id,
                        chapter.Story.Title,
                    },
                    User = new UserDto(chapter.User),
                    Comments = chapter.Comments
                       .OrderBy(c => c.CreatedOn)
                       .Select(comment => new
                       {
                           comment.Id,
                           comment.Content, 
                           comment.CreatedOn, 
                           User = new UserDto(comment.User),
                       })


                });
            });

            //Post/Put 

            //Delete



        }
    }
}
