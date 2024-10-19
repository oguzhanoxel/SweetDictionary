using Core.Results;
using SweetDictionary.Domain.Dtos.User.RequestDtos;
using SweetDictionary.Domain.Dtos.User.ResponseDtos;

namespace SweetDictionary.Application.Services.Abstracts;

public interface IUserService
{
	DataResult<UserResponseDto> Create(CreateUserRequestDto dto);
	DataResult<UserResponseDto> Update(UpdateUserRequestDto dto);
	DataResult<UserResponseDto> Delete(DeleteUserRequestDto dto);
	DataResult<List<UserResponseDto>> GetAll();
	DataResult<UserResponseDto> GetById(Guid id);
}
