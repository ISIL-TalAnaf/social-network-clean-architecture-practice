using System;

namespace AnafSocial.Domain.Entities;

public class Follow
{
    public Guid Id { get; set; }
    public Guid FollowerId { get; set; }
    public Guid FollowingId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
