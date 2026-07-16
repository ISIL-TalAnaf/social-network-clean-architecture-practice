
using System;
namespace AnafSocial.Application.DTOs;


public interface ILikeService
{
    Task LikeAsync(Guid postId, Guid userId);
    Task UnlikeAsync(Guid postId, Guid userId);
}