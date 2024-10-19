namespace SweetDictionary.Domain.Dtos.Post.ResponseDtos;

public sealed record PostDetailResponseDto(
	Guid Id,
	string Title,
	string Content,
	Guid AuthorId,
	string AuthorFirstName,
	string AuthorLastName,
	string AuthorEmail,
	string AuthorUsername,
	Guid CategoryId,
	string CategoryName);
