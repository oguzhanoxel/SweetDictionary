using Core.Results;
using SweetDictionary.Domain.Dtos.User.RequestDtos;
using SweetDictionary.Domain.Dtos.User.ResponseDtos;

namespace SweetDictionary.Application.Services.Abstracts;

public interface IUserService
{
	DataResult<UserResponseDto> Create(CreateUserRequestDto dto);
	DataResult<UserResponseDto> Update(Guid id, UpdateUserRequestDto dto);
	DataResult<UserResponseDto> Delete(Guid id);
	DataResult<List<UserResponseDto>> GetAll();
	DataResult<UserResponseDto> GetById(Guid id);
}
