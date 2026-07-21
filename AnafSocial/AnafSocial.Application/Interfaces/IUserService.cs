
using System;
using AnafSocial.Application.DTOs;

namespace AnafSocial.Application.Interfaces;

public interface IUserService
{
    Task<UserProfileDto> GetProfileAsync(Guid userId);
    Task FollowAsync(Guid followerId, Guid followingID);
    Task UnfollowAsync(Guid followerId, Guid followingID);
    Task<IEnumerable<UserProfileDto>> GetFollowersAsync(Guid userId);
    Task<IEnumerable<UserProfileDto>> GetFollowingAsync(Guid userId);

}