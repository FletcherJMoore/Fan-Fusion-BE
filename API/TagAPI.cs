using FanFusion_BE.Data;
using FanFusion_BE.DTO;
using FanFusion_BE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata.Ecma335;

namespace FanFusion_BE.API
{
    public class TagAPI
    {
        public static void Map(WebApplication app)
        {
   
            // get all tags
            app.MapGet("/tags", (FanFusionDbContext db) =>
            {
                var allTags = db.Tags.ToList();

                var tagDtos = allTags.Select(tag => new TagDto(tag)).ToList();
                if (!tagDtos.Any())
                {
                    return Results.Ok("There are no aviliable tags to display");
                }
                return Results.Ok(tagDtos);
            });

            //Get Single 
            app.MapGet("/tags/{tagId}", (FanFusionDbContext db, int tagId) =>
            {
                Tag? tag = db.Tags
                .Include(t => t.Stories)
                .SingleOrDefault(t => t.Id == tagId);

                if (tag == null)
                {
                    return Results.NotFound($"No tag was found with the following id: {tagId}");
                }

                return Results.Ok(new
                {
                    tag.Id,
                    tag.Name,
                    Stories = tag.Stories?.Select(story => new StoryDTO(story)).OrderByDescending(story => story.DateCreated).ToList(),
                });
            });


        }
    }
}
