namespace SweetDictionary.Domain.Dtos.User.RequestDtos;

public record RegisterRequestDto(
	string FirstName,
	string LastName,
	string UserName,
	string Email,
	DateTime BirthDate,
	string Password);
