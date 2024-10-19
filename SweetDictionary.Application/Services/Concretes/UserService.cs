using AutoMapper;
using Core.Results;
using SweetDictionary.Application.Services.Abstracts;
using SweetDictionary.Domain.Dtos.User.RequestDtos;
using SweetDictionary.Domain.Dtos.User.ResponseDtos;
using SweetDictionary.Domain.Entities;
using SweetDictionary.Persistence.Repositories.Abstracts;

namespace SweetDictionary.Application.Services.Concretes;

public class UserService : IUserService
{
	private readonly IUserRepository _userRepository;
	private readonly IMapper _mapper;

	public UserService(IUserRepository userRepository, IMapper mapper)
	{
		_userRepository = userRepository;
		_mapper = mapper;
	}

	public DataResult<UserResponseDto> Create(CreateUserRequestDto dto)
	{
		User created = _mapper.Map<User>(dto);
		created.Id = Guid.NewGuid();
		var user = _userRepository.Create(created);
		UserResponseDto response = _mapper.Map<UserResponseDto>(user);

		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.Created);
	}

	public DataResult<UserResponseDto> Delete(DeleteUserRequestDto dto)
	{
		User deleted = _mapper.Map<User>(dto);
		var user = _userRepository.Delete(deleted);
		UserResponseDto response = _mapper.Map<UserResponseDto>(user);

		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}

	public DataResult<List<UserResponseDto>> GetAll()
	{
		var users = _userRepository.GetAll();
		List<UserResponseDto> response = _mapper.Map<List<UserResponseDto>>(users);
		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}

	public DataResult<UserResponseDto> GetById(Guid id)
	{
		var user = _userRepository.Get(p => p.Id == id);
		UserResponseDto response = _mapper.Map<UserResponseDto>(user);
		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}

	public DataResult<UserResponseDto> Update(UpdateUserRequestDto dto)
	{
		User updated = _mapper.Map<User>(dto);
		var user = _userRepository.Update(updated);
		UserResponseDto response = _mapper.Map<UserResponseDto>(user);

		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}
}
