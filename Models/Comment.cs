namespace FanFusion_BE.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UserUid { get; set; }
        public User User { get; set; }
        public int ChapterId { get; set; }
        public Chapter Chapter { get; set; }

    }
}
