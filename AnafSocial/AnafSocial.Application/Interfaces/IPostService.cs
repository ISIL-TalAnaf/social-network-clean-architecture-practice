
using System;
using AnafSocial.Application.DTOs;

namespace AnafSocial.Application.Interfaces;

public interface IPostService
{

    Task <CreatePostDto> CreatePostAsync (CreatePostDto dto);
    Task<PostResponseDto> GetPostByIdAsync (Guid postId);

    Task<IEnumerable<PostResponseDto>> GetFeedAsync();

    Task DeleteAsync(Guid postId, Guid requestingUserId);


}