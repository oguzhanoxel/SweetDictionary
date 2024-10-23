namespace SweetDictionary.Domain.Dtos.Comment.ResponseDtos;

public sealed record CommentDetailResponseDto(
	Guid Id,
	string Text,
	Guid PostId,
	string PostTitle,
	string PostContent,
	string UserId,
	string UserFirstName,
	string UserLastName,
	string UserEmail,
	string UserUsername);