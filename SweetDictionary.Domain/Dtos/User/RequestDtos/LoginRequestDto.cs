namespace SweetDictionary.Domain.Dtos.User.RequestDtos;

public record LoginRequestDto(
	string UserName,
	string Password);