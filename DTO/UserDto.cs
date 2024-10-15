using FanFusion_BE.Models;
using System.Globalization;

namespace FanFusion_BE.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Uid { get; set; }
        public string Image {  get; set; }
        public UserDto(User user)
        {
            Id = user.Id;
            Username = user.Username;
            Uid = user.Uid;
            Image = user.Image;
        }

    }
}
