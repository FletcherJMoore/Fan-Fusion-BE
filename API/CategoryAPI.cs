using FanFusion_BE.DTO;

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

        }
    }
}
