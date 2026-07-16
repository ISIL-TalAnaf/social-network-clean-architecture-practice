
using System;
namespace AnafSocial.Application.DTOs;


public interface IUserService
{
    Task<UserProfileDto> GetProfileAsync(Guid userId);
    Task FollowAsync(Guid followerId, Guid followingID);
    Task UnfollowAsync(Guid followerId, Guid followingID);
    Task<IEnumerable<UserProfileDto>> GetFollowersAsync(Guid userId);
    Task<IEnumerable<UserProfileDto>> GetFollowingAsync(Guid userId);

}