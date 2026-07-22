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

public class PostService : IPostService
{
    private readonly IUnitOfWork _unitOfWork;
    public PostService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    Task<PostResponseDto> CreateAsync(Guid userId, CreatePostDto dto)
    {
        var user = _unitOfWork.Users.GetByUserIdAsync(userId);
        if (user == null)
        {
            throw new Exception("User is null");
        }
        if (string.IsNullOrEmpty(dto.Content))
        {
            throw new Exception("The post content is empty");
        }

        // Implementation for creating a post goes here
        _unitOfWork.Posts.AddPostAsync(new Post
        {
            UserId = userId,
            Content = dto.Content,
            ImageUrl = dto.ImageUrl,
            CreatedAt = DateTime.UtcNow
        });
        _unitOfWork.SaveChangesAsync();
        return Task.CompletedTask;

    }

    public async Task<PostResponseDto> GetPostByIdAsync(Guid postId)
    {
        var post = await _unitOfWork.Posts.GetPostByIdAsync(postId);
        if (post == null)
        {
            throw new Exception("Post not found");
        }

        return new PostResponseDto
        {
            Id = post.Id,
            AuthorUsername = post.Author.UserName,
            Content = post.Content,
            ImageUrl = post.ImageUrl,
            CreatedAt = post.CreatedAt,
            LikesCount = post.LikesCount,
            CommentsCount = post.CommentsCount,
            // UpdatedAt = post.UpdatedAt
        };
    }

    public Task<IEnumerable<PostResponseDto>> GetFeedAsync()
    {
        if (_unitOfWork.Posts == null)
        {
            throw new Exception("Posts repository is null");
        }

        return _unitOfWork.Posts.GetAllPostsAsync();


    }

    public Task DeleteAsync(Guid postId, Guid requestingUserId)
    {
        var post = _unitOfWork.Posts.GetPostByIdAsync(postId);
        var user = _unitOfWork.Users.GetByUserIdAsync(requestingUserId);
        if (post == null)
        {

            throw new Exception("Post not found");
        }
        else
        {
            if (user == null || user.Id != post.UserId)
            {
                throw new Exception("User not authorized to delete this post");
            }
        }
        _unitOfWork.Posts.DeletePostAsync(postId);
        return Task.CompletedTask;

    }
}





