﻿namespace FanFusion_BE.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Story> Stories { get; set; }
    }
}
