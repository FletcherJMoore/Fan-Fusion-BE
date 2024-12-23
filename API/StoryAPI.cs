﻿using FanFusion_BE.DTO;
using FanFusion_BE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace FanFusion_BE.API
{
    public class StoryAPI
    {
        public static void Map(WebApplication app)
        {
            //GET ALL STORIES
            app.MapGet("/stories", (FanFusionDbContext db) =>
            {
            var allStories = db.Stories.ToList();
            var storyDTOs = allStories.Select(story => new StoryDTO(story)).OrderByDescending(story => story.DateCreated).ToList();
            

            if (!storyDTOs.Any())
            {
                return Results.Ok("There are no stories");
            }
                return Results.Ok(storyDTOs);
            });

            //GET SINGLE STORY AND IT'S CHAPTERS (SaveAsDraft: false)
            app.MapGet("/stories/{storyId}", (FanFusionDbContext db, int storyId) => 
            {
                Story? story = db.Stories
                .Include(s => s.Chapters)
                .Include(s => s.Tags)
                .Include(s => s.User)
                .SingleOrDefault(s => s.Id == storyId);

                if (story == null)
                {
                    return Results.NotFound($"The story with the following id was not found: {storyId}");
                }

                return Results.Ok(new
                {
                    story.Id,
                    story.Title,
                    story.Description,
                    story.Image,
                    story.DateCreated,
                    story.TargetAudience,
                    story.UserId,
                    story.CategoryId,
                    Chapters = story.Chapters.Select(story => new
                    {
                        story.Id,
                        story.Title,
                        story.DateCreated,
                    }),
                    Tags = story.Tags?.Select(tag => new TagDto(tag)).ToList(),
                    User = new UserDto(story.User),
                });
            });

            //CREATE NEW STORY
            app.MapPost("/stories", (FanFusionDbContext db, Story story) =>
            {
                // Check if the stories's author exists
                if (!db.Users.Any(user => user.Id == story.UserId))
                {
                    return Results.NotFound($"No user found with the following id: {story.UserId}");
                }
                else if (!db.Categories.Any(category => category.Id == story.CategoryId))
                {
                    return Results.NotFound($"No category was found with the following id: {story.CategoryId}");
                }

                Story newStory = new()
                {
                    Title = story.Title,
                    Description = story.Description,
                    Image = story.Image,
                    DateCreated = DateTime.Now,
                    UserId = story.UserId,
                    TargetAudience = story.TargetAudience,
                    CategoryId = story.CategoryId,
                };

                db.Stories.Add(newStory);
                db.SaveChanges();

                return Results.Created($"/stories/{newStory.Id}", newStory);
            });

            //EDIT STORY BY ID 
            app.MapPut("/stories/{storyId}", (FanFusionDbContext db, Story story, int storyId) =>
            {
                Story updatedStory = db.Stories.SingleOrDefault(story => story.Id == storyId);

                if (updatedStory == null)
                {
                    return Results.NotFound($"No story found with the follow id: {storyId}");
                }
                else if (!db.Users.Any(user => user.Id == story.UserId))
                {
                    return Results.NotFound($"No user found with the following id: {story.UserId}");
                }
                else if (!db.Categories.Any(category => category.Id == story.CategoryId))
                {
                    return Results.NotFound($"No category was found with the following id: {story.CategoryId}");
                }
                updatedStory.Title = story.Title;  
                updatedStory.Description = story.Description;
                updatedStory.Image = story.Image;
                updatedStory.UserId = story.UserId;  
                updatedStory.TargetAudience = story.TargetAudience;
                updatedStory.CategoryId = story.CategoryId;

                db.SaveChanges();
                return Results.Ok(updatedStory);
            });

            //DELETE STORY 
            app.MapDelete("/stories/{storyId}", (FanFusionDbContext db, int storyId) =>
            {
                //FIND THE STORY
                Story story = db.Stories
                .Include(s => s.Chapters)
                .FirstOrDefault(s => s.Id == storyId);

                if (story == null)
                {
                    return Results.NotFound($"No story was found with the following id: {storyId}");
                }
                // REMOVE ALL ACCOCIATED CHAPTERS
                db.Chapters.RemoveRange(story.Chapters);

                //REMOVE STORY
                db.Stories.Remove(story);
                db.SaveChanges();

                return Results.Ok(story);
            });

            //Search 
            app.MapGet("/stories/search", (FanFusionDbContext db, string searchValue) =>
            {
                if (string.IsNullOrWhiteSpace(searchValue))
                {
                    return Results.BadRequest("Search value cannot be empty.");
                }
                var searchResults = db.Stories
                .Where(story =>
                    story.Title.ToLower().Contains(searchValue.ToLower()) ||
                    story.Category != null && story.Category.Title.ToLower().Contains(searchValue.ToLower()) ||
                    story.Tags.Any(tag => tag.Name.ToLower().Contains(searchValue.ToLower()) ||
                    story.User != null && (story.User.FirstName.ToLower().Contains(searchValue.ToLower()) ||
                    story.User.LastName.ToLower().Contains(searchValue.ToLower()) ||
                    story.User.Username.ToLower().Contains(searchValue.ToLower())) ||
                    story.TargetAudience.ToLower().Contains(searchValue.ToLower()))
                )

                .OrderByDescending(story => story.DateCreated)
                .Select(story => new StoryDTO(story))
                .ToList();

                if (!searchResults.Any())
                {
                    return Results.Ok("No stories found for this search.");
                }
                return Results.Ok(searchResults);
            });

            //GET STORIES BY CATEGORY
            app.MapGet("/stories/categories/{categoryId}", (FanFusionDbContext db, int categoryId) =>
            {
                var category = db.Categories.FirstOrDefault(c => c.Id == categoryId);

                // Check if the category exists
                if (category == null)
                {
                    return Results.NotFound($"Category with ID {categoryId} not found.");
                }

                var stories = db.Stories
                    .Where(c => c.CategoryId == categoryId)
                    .ToList();

                var storyDTOs = stories
                   .Select(story => new StoryDTO(story))
                   .OrderByDescending(dto => dto.DateCreated)
                   .ToList();

                if (!stories.Any())
                {
                    return Results.NotFound("No stories found for this category.");
                }

                return Results.Ok(storyDTOs);
            });
        }
    }
}
