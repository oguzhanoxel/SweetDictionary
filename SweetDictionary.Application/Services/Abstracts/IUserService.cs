using Core.Results;
using SweetDictionary.Domain.Dtos.User.ResponseDtos;

namespace SweetDictionary.Application.Services.Abstracts;

public interface IUserService
{
	Task<DataResult<List<UserResponseDto>>> GetAllAsync();
	Task<DataResult<UserResponseDto>> GetByIdAsync(string id);
}
