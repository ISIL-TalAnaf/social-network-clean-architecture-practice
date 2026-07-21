
using System;
using AnafSocial.Application.DTOs;

namespace AnafSocial.Application.Interfaces;

public interface ILikeService
{
    Task LikeAsync(Guid postId, Guid userId);
    Task UnlikeAsync(Guid postId, Guid userId);
}