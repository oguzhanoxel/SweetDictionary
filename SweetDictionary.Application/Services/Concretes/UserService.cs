using AutoMapper;
using Core.Results;
using SweetDictionary.Application.Services.Abstracts;
using SweetDictionary.Domain.Dtos.Post.ResponseDtos;
using SweetDictionary.Domain.Dtos.User.RequestDtos;
using SweetDictionary.Domain.Dtos.User.ResponseDtos;
using SweetDictionary.Domain.Entities;
using SweetDictionary.Persistence.Repositories.Abstracts;
using SweetDictionary.Persistence.Repositories.Concretes;

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

	public DataResult<UserResponseDto> Delete(Guid id)
	{
		User? user = _userRepository.Get(x => x.Id == id);

		if (user is null) return ResultFactory.Failure<UserResponseDto>(
			null,
			message: "Not Found",
			statusCode: System.Net.HttpStatusCode.NotFound);

		var deleted = _userRepository.Delete(user);
		UserResponseDto response = _mapper.Map<UserResponseDto>(deleted);

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
		User? user = _userRepository.Get(x => x.Id == id);

		if (user is null) return ResultFactory.Failure<UserResponseDto>(
			null,
			message: "Not Found",
			statusCode: System.Net.HttpStatusCode.NotFound);

		UserResponseDto response = _mapper.Map<UserResponseDto>(user);
		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}

	public DataResult<UserResponseDto> Update(Guid id, UpdateUserRequestDto dto)
	{
		User? user = _userRepository.Get(x => x.Id == id);

		if (user is null) return ResultFactory.Failure<UserResponseDto>(
			null,
			message: "Not Found",
			statusCode: System.Net.HttpStatusCode.NotFound);

		_mapper.Map(dto, user);
		var updated = _userRepository.Update(user);
		UserResponseDto response = _mapper.Map<UserResponseDto>(updated);

		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}
}
