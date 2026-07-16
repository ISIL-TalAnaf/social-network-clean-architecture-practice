namespace AnafSocial.Application.DTOs;

public record PostResponseDto(Guid Id, string AuthorUsername, string Content, string? ImageUrl, DateTime CreatedAt, int LikesCount, int CommentsCount);
