namespace SweetDictionary.Domain.Dtos.Comment.RequestDtos;

public sealed record CreateCommentRequestDto(string Text, Guid PostId, string UserId);
