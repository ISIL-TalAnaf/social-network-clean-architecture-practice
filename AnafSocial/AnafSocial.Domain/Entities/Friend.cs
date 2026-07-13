using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnafSocial.Domain.Entities;

internal class Friend
    {
    [Key]
    public Guid FollowingId { get; set; }
    [Key]
    public Guid FollowerId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

}

