using FanFusion_BE.DTO;
using FanFusion_BE.Models;
using Microsoft.EntityFrameworkCore;

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

            // Create or Update Chapter (Used for both the publish and save as draft btn in the chapter form)
            app.MapPost("/chapters", async (FanFusionDbContext db, Chapter newChapter) =>
            {

                // Find the existing chapter if it exists
                var existingChapter = await db.Chapters.FindAsync(newChapter.Id);

                if (existingChapter != null)
                {
                    // Update existing chapter by directly modifying properties
                    existingChapter.Title = newChapter.Title;
                    existingChapter.Content = newChapter.Content;
                    existingChapter.SaveAsDraft = newChapter.SaveAsDraft;
                    await db.SaveChangesAsync(); // Save the changes to the database

                    return Results.Ok(existingChapter); // Return the updated chapter
                }
                else
                {
                    // Check if the chapter's author exists
                    if (!db.Users.Any(user => user.Id == newChapter.UserId))
                    {
                        return Results.NotFound($"No user found with the following id: {newChapter.UserId}");
                    }
                    else if (!db.Stories.Any(story => story.Id == newChapter.StoryId))
                    {
                        return Results.NotFound($"No story was found with the following id: {newChapter.StoryId}");
                    }
                    // Create new chapter
                    Chapter addChapter = new()
                    {
                        Title = newChapter.Title,
                        Content = newChapter.Content,
                        UserId = newChapter.UserId,
                        SaveAsDraft = newChapter.SaveAsDraft,
                        DateCreated = DateTime.Now,
                        StoryId = newChapter.StoryId,
                    };

                    await db.Chapters.AddAsync(addChapter);
                    await db.SaveChangesAsync();

                    return Results.Created($"chapters/{addChapter.Id}", addChapter);
                }
            });

            //Delete
            app.MapDelete("/chapters/{chapterId}", (FanFusionDbContext db, int chapterId) =>
            {
                Chapter chapter = db.Chapters
                .SingleOrDefault(ch => ch.Id == chapterId);

                if (chapter == null)
                {
                    return Results.NotFound($"There is no chapter with the following id: ${chapterId}");
                }
                db.Chapters.Remove(chapter);
                db.SaveChanges();

                return Results.Ok(chapter);
            });



        }
    }
}
