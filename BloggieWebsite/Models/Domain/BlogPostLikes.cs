﻿namespace BloggieWebsite.Models.Domain
{
    public class BlogPostLikes
    {
        public Guid Id { get; set; }
        public Guid BlogPostId { get; set; }
        public Guid UserId { get; set; }
    }
}
