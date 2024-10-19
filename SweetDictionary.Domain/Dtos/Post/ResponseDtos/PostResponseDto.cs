namespace SweetDictionary.Domain.Dtos.Post.ResponseDtos;

public sealed record PostResponseDto(
	Guid Id, 
	string Title, 
	string Content,
	Guid AuthorId,
	Guid CategoryId);
