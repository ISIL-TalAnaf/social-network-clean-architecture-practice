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

public class UserService: IUserService
{

    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<UserProfileDto> GetProfileAsync(Guid userId)
    {
        var user = await _unitOfWork.Users.GetByUserIdAsync(userId);
        if (user is null)
            throw new KeyNotFoundException("User not found.");

        var followers = await _unitOfWork.Follows.GetFollowersAsync(userId);
        var following = await _unitOfWork.Follows.GetFollowingAsync(userId);

        return new UserProfileDto(
            user.Id,
            user.UserName,
            user.Bio,
            null, 
            followers.Count(),
            following.Count()
        );
    }
    public async Task FollowAsync(Guid followerId, Guid followingID)
    {
        if (followerId == followingID)
        {
            throw new InvalidOperationException("A user cannot follow themselves.");
        }
        var existingFollow = await _unitOfWork.Follows.GetAsync(followerId, followingID);
        if (existingFollow is not null) {
            throw new InvalidOperationException("The user is already following the specified user.");
        }
        var follow = new Follow
        {
            FollowerId = followerId,
            FollowingId = followingID,
            CreatedAt = DateTime.UtcNow
        };
        await _unitOfWork.Follows.AddAsync(follow);
        await _unitOfWork.SaveChangesAsync();
    }
    public async Task UnfollowAsync(Guid followerId, Guid followingID)
    {
        if (followerId == followingID)
        {
            throw new InvalidOperationException("A user cannot follow themselves.");
        }
        var existingFollow = await _unitOfWork.Follows.GetAsync(followerId, followingID);
        if (existingFollow is null) {
            throw new InvalidOperationException("The user is not following the specified user.");
        }
        _unitOfWork.Follows.Remove(existingFollow);
        await _unitOfWork.SaveChangesAsync();
    }
    public async Task<IEnumerable<UserProfileDto>> GetFollowersAsync(Guid userId)
    {
        if(userId == Guid.Empty)
        {
            throw new ArgumentException("User ID cannot be empty.", nameof(userId));
        }

       
        var followers = await _unitOfWork.Follows.GetFollowersAsync(userId);

        return followers.Select(f => new UserProfileDto(
            f.Id,
            f.UserName,
            f.Bio,
            null,
            0,
            0
        ));



    }
    public async Task<IEnumerable<UserProfileDto>> GetFollowingAsync(Guid userId)
    {
        if (userId == Guid.Empty)
        {
            throw new ArgumentException("User ID cannot be empty.", nameof(userId));
        }

        var user = await _unitOfWork.Users.GetByUserIdAsync(userId);
        var following = await _unitOfWork.Follows.GetFollowingAsync(userId);
        return following.Select(f => new UserProfileDto(
            f.Id,
            f.UserName,
            f.Bio,
            null,
            0,
            0
        ));


    }



}
