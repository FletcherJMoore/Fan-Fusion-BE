using FanFusion_BE.Models;
using System.Globalization;

namespace FanFusion_BE.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Uid { get; set; }
        public string Image {  get; set; }
        public UserDto(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Username;
            Uid = user.Uid;
            Image = user.Image;
        }

    }
}
