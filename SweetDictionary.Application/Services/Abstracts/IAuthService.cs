using Core.Results;
using SweetDictionary.Domain.Dtos.User.RequestDtos;
using SweetDictionary.Domain.Dtos.User.ResponseDtos;

namespace SweetDictionary.Application.Services.Abstracts;

public interface IAuthService
{
	Task<DataResult<UserResponseDto>> RegisterAsync(RegisterRequestDto dto);
}
