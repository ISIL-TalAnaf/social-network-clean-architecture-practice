using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnafSocial.Domain.Entities;

public class Comment
{
    [Key]
    public Guid Id { get; set; }
    [Key]
    public Guid PostId { get; set; }
    public Guid UserId  { get; set; }

    public required string Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

}