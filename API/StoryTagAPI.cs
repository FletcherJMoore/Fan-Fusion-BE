using FanFusion_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace FanFusion_BE.API
{
    public class StoryTagAPI
    {
        public static void Map(WebApplication app)
        {
            // add tag to story 
            app.MapPost("/stories/{storyId}/add-tag/{tagId}", (FanFusionDbContext db, int tagId, int storyId) =>
            {
                Story? story = db.Stories
                .Include(s => s.Tags)
                .FirstOrDefault(s => s.Id == storyId);

                if (story == null)
                {
                    return Results.NotFound($"There is no story with the following id: {storyId}");
                }

                Tag? tag = db.Tags.FirstOrDefault(t => t.Id == tagId);
                if (tag == null)
                {
                    return Results.NotFound($"There is no tag with the following id: {tagId}");
                }
                else if (story.Tags.Contains(tag))
                {
                    return Results.Ok("This post already has this tag.");
                }

                story.Tags.Add(tag);
                db.SaveChanges();
                return Results.Ok("This tag has been added.");
            });

            // remove tag from story 
            app.MapDelete("/stories/{storyId}/remove-tag/{tagId}", (FanFusionDbContext db, int tagId, int storyId) =>
            {
                Story? story = db.Stories
                .Include(s => s.Tags)
                .FirstOrDefault(s => s.Id == storyId);

                if (story == null)
                {
                    return Results.NotFound($"There is no stories with the following id: {storyId}");
                }

                Tag? tag = db.Tags.FirstOrDefault(tag => tag.Id == tagId);
                if (tag == null)
                {
                    return Results.NotFound($"There is no tags with the following id: {tagId}");
                }
                else if (!story.Tags.Contains(tag))
                {
                    return Results.Ok("Story does not have tag");
                }

                story.Tags.Remove(tag);
                db.SaveChanges();
                return Results.Ok("Tag removed");
            });


        }
    }
}
