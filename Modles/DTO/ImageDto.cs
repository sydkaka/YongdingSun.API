﻿namespace YongdingSun.API.Modles.DTO
{
    public class ImageDto
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int Likes { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
