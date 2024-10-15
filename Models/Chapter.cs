namespace FanFusion_BE.Models
{
    public class Chapter
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public int StoryId { get; set; }
        public Story Story { get; set; }
        public bool SaveAsDraft { get; set; }
        public List<Comment>? Comments { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
