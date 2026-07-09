using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnafSocial.Domain.Entities;

public class Post
{
    [Key]
    public Guid Id { get; set; }
    
    public User Author { get; set; } = new User();
    [Required]
    [StringLength(500)]
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Like> Likes { get; set; } = new List<Like>();



} 