using FanFusion_BE.Models;

namespace FanFusion_BE.DTO
{
    public class ChapterDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public int StoryId { get; set; }
        public bool SaveAsDraft { get; set; }
        public ChapterDto(Chapter chapter)
        {
            Id = chapter.Id;
            Title = chapter.Title;
            Content = chapter.Content;
            DateCreated = chapter.DateCreated;
            StoryId = chapter.StoryId;
            SaveAsDraft = chapter.SaveAsDraft;
        }

    }
}
