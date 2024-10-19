namespace SweetDictionary.Domain.Dtos.User.RequestDtos;

public sealed record CreateUserRequestDto(string FirstName, string LastName, string Email, string Username, string Password);
