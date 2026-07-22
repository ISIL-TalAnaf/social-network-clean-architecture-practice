using System;
using System.Collections.Generic;

namespace AnafSocial.Domain.Entities;

public class Post
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public User Author { get; set; } = new User();

    public string Content { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public ICollection<Like> Likes { get; set; } = new List<Like>();
}