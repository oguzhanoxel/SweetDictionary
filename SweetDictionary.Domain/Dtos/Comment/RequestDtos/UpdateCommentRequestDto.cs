namespace SweetDictionary.Domain.Dtos.Comment.RequestDtos;

public sealed record UpdateCommentRequestDto(Guid Id, string Text, Guid PostId, Guid UserId);
