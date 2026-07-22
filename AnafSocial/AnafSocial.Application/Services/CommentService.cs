using AnafSocial.Application.DTOs;
using AnafSocial.Application.Interfaces;
using AnafSocial.Domain.Entities;
using AnafSocial.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AnafSocial.Application.Services;

public class CommentService : ICommentService
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly ICommentRepository _commentRepository;
    private readonly IUserRepository _userRepository;
    private readonly IPostRepository _postRepository;
    public CommentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _commentRepository = unitOfWork.Comments;
        _userRepository = unitOfWork.Users; 
        _postRepository = unitOfWork.Posts;
    }
    public async Task<CommentResponseDto> AddAsync(Guid postId, Guid userId, CreateCommentDto dto)
    {
        var post = await _postRepository.GetByIdAsync(postId);
        var user = await _userRepository.GetByIdAsync(userId);
        var comment = new Comment
        {
            Id = Guid.NewGuid(),
            PostId = postId,
            UserId = userId,
            Content = dto.Content,
            CreatedAt = DateTime.UtcNow
        };
      
        if (post == null || user == null || string.IsNullOrWhiteSpace(dto.Content))
        {
            throw new ArgumentException("Post, User, or Content not found.");
        }

        await _commentRepository.AddAsync(comment);
        await _unitOfWork.SaveChangesAsync();

        return new CommentResponseDto
        {
            Id = comment.Id,
            AuthorUsername = user.UserName,
            Content = comment.Content,
            CreatedAt = comment.CreatedAt
        };



    }
     public async Task<IEnumerable<CommentResponseDto>> GetForPostAsync(Guid postId)
    {
   
        var comments = await _unitOfWork.Comments.GetByPostIdAsync(postId);

        return comments.Select(comment => new CommentResponseDto
        {
            Id = comment.Id,
            AuthorUsername = _unitOfWork.Users.GetByIdAsync(comment.UserId).Result.UserName,
            Content = comment.Content,
            CreatedAt = comment.CreatedAt
        });
    }

}

