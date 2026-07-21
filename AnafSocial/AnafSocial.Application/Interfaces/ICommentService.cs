
using System;
using AnafSocial.Application.DTOs;

namespace AnafSocial.Application.Interfaces;

public interface ICommentService
{
    Task<CommentResponseDto> AddAsync(Guid postId, Guid userId, CreateCommentDto dto);
    Task<IEnumerable<CommentResponseDto>> GetForPostAsync(Guid postId);
}