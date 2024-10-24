namespace SweetDictionary.Domain.Dtos.User.RequestDtos;

public record LoginRequestDto(
	string Email,
	string Password);