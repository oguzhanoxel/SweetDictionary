namespace SweetDictionary.Domain.Dtos.User.ResponseDtos;

public sealed record UserResponseDto(
	string Id, 
	string FirstName, 
	string LastName, 
	string Email, 
	string UserName);
