
using System;
namespace AnafSocial.Application.DTOs;

public interface IPostService
{

    Task <CreatePostDto> CreatePostAsync (CreatePostDto dto);
    Task<PostResponseDto> GetPostByIdAsync (Guid postId);

    Task<IEnumerable<PostResponseDto>> GetFeedAsync();

    Task DeleteAsync(Guid postId, Guid requestingUserId);


}