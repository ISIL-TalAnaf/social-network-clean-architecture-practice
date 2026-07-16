namespace AnafSocial.Application.DTOs;

public record CommentResponseDto(Guid Id, string AuthorUsername, string Content, DateTime CreatedAt);
