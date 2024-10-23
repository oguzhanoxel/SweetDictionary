namespace SweetDictionary.Domain.Dtos.Comment.RequestDtos;

public sealed record UpdateCommentRequestDto(string Text, Guid PostId, string UserId);
