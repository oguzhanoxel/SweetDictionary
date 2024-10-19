namespace SweetDictionary.Domain.Dtos.User.ResponseDtos;

public sealed record UserResponseDto(
	Guid Id, 
	string FirstName, 
	string LastName, 
	string Email, 
	string Username, 
	string Password);
