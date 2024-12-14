using Core.Results;
using SweetDictionary.Domain.Dtos.User.RequestDtos;

namespace SweetDictionary.Application.Services.Abstracts;

public interface IAuthService
{
	Task<Result> Register(RegisterRequestDto dto, string role);
	Task<DataResult<string>> Login(LoginRequestDto dto);
}
