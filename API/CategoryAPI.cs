using FanFusion_BE.DTO;
using FanFusion_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace FanFusion_BE.API
{
    public class CategoryAPI
    {
        public static void Map(WebApplication app)
        {
            // get all categories
            app.MapGet("/categories", (FanFusionDbContext db) =>
            {
                var allCategories = db.Categories.ToList();

                if (!allCategories.Any())
                {
                    return Results.Ok("There are no aviliable categories to display");
                }
                return Results.Ok(allCategories);
            });

            //get movie's by genre 
            app.MapGet("/categories/{id}/stories", (FanFusionDbContext db, int id) =>
            {
                var category = db.Categories.FirstOrDefault(c => c.Id == id);

                // Check if the category exists
                if (category == null)
                {
                    return Results.NotFound($"Category with ID {id} not found.");
                }

                var stories = db.Stories
                    .Include(s => s.Category)
                    .Where(c => c.CategoryId == id)
                    .Select(s => new
                    {
                        s.Id,
                        s.Image,
                        s.Title,
                        s.CategoryId,
                    })
                    .ToList();

                if (!stories.Any())
                {
                    return Results.NotFound("No stories found for this category.");
                }

                return Results.Ok(stories);
            });

        }
    }
}
