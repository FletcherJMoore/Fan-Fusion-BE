using FanFusion_BE.Models;

namespace FanFusion_BE.DTO
{
    public class TagDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TagDto(Tag tag) 
        {
            Id = tag.Id;
            Name = tag.Name;
        }
    }
}

