
using System;
namespace AnafSocial.Application.DTOs;

public interface ICommentService
{
    Task<CommentResponseDto> AddAsync(Guid postId, Guid userId, CreateCommentDto dto);
    Task<IEnumerable<CommentResponseDto>> GetForPostAsync(Guid postId);
}