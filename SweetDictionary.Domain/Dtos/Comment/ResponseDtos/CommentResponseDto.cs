namespace SweetDictionary.Domain.Dtos.Comment.ResponseDtos;

public sealed record CommentResponseDto(
	Guid Id, 
	string Text, 
	Guid PostId, 
	string UserId);
