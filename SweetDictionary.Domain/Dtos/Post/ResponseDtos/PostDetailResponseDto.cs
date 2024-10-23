namespace SweetDictionary.Domain.Dtos.Post.ResponseDtos;

public sealed record PostDetailResponseDto(
	Guid Id,
	string Title,
	string Content,
	string AuthorId,
	string AuthorFirstName,
	string AuthorLastName,
	string AuthorEmail,
	string AuthorUsername,
	Guid CategoryId,
	string CategoryName);
