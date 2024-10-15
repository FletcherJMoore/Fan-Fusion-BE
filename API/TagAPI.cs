namespace FanFusion_BE.API
{
    public class TagAPI
    {
        public static void Map(WebApplication app)
        {
            // add tag to story 

            // remove tag from story 
            //app.Map

            // get all tags
            app.MapGet("/tags", (FanFusionDbContext db) =>
            {
                var tags = db.Tags.ToList();
                if (!tags.Any())
                {
                    return Results.Ok("There are no aviliable tags to display");
                }
                return Results.Ok(tags);
            });


        }
    }
}
