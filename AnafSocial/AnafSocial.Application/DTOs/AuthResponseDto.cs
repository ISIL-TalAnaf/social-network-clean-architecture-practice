namespace AnafSocial.Application.DTOs;

public record AuthResponseDto(string Token, string Username, Guid UserId, DateTime ExpiresAt);
