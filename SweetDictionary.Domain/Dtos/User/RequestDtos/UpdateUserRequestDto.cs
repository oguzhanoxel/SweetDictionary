namespace SweetDictionary.Domain.Dtos.User.RequestDtos;

public sealed record UpdateUserRequestDto(string FirstName, string LastName, string Email, string Username, string Password);
