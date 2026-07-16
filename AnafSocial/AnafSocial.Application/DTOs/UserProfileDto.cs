namespace AnafSocial.Application.DTOs;

public record UserProfileDto(Guid Id, string Username, string? Bio, string? ProfilePictureUrl, int FollowersCount, int FollowingCount);
