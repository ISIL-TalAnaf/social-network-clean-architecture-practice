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

public class LikeService : ILikeService
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly ICommentRepository _commentRepository;
    private readonly IUserRepository _userRepository;
    private readonly IPostRepository _postRepository;
    public LikeService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task LikeAsync(Guid postId, Guid userId)
    {
        var post =  _postRepository.GetByIdAsync(postId);
        var user = _userRepository.GetByIdAsync(userId);
        if(post == null|| user == null)
        {
            throw new Exception("User or post not found");

        }

        var existingLike =  _unitOfWork.Likes.GetAsync(postId, userId);
        if (existingLike is not null)
        {
            throw new Exception("Already did like");
        }

        var like = new Like(
            UserId = userId,
            PostId = postId
            );
        await _unitOfWork.Likes.AddAsync(like);
        await _unitOfWork.SaveChangesAsync();
        return Task.CompletedTask;
    }
    public Task UnlikeAsync(Guid postId, Guid userId)
    {
        var post = _postRepository.GetByIdAsync(postId);
        var user = _userRepository.GetByIdAsync(userId);
        if (post == null || user == null)
        {
            throw new Exception("User or post not found");

        }

        var existingLike = _unitOfWork.Likes.GetAsync(postId, userId);
        if (existingLike is null)
        {
            throw new Exception("The User did not did like");
        }

        
        await _unitOfWork.Likes.RemoveAsync(like);
        await _unitOfWork.SaveChangesAsync();
        return Task.CompletedTask;
    }

}