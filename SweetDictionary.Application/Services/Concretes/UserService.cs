using AutoMapper;
using Core.Results;
using Microsoft.AspNetCore.Identity;
using SweetDictionary.Application.Services.Abstracts;
using SweetDictionary.Domain.Dtos.Post.ResponseDtos;
using SweetDictionary.Domain.Dtos.User.ResponseDtos;
using SweetDictionary.Domain.Entities;

namespace SweetDictionary.Application.Services.Concretes;

public class UserService : IUserService
{
	private readonly UserManager<User> _userManager;
	private readonly IMapper _mapper;

	public UserService(UserManager<User> userManager, IMapper mapper)
	{
		_userManager = userManager;
		_mapper = mapper;
	}

	public async Task<DataResult<List<UserResponseDto>>> GetAllAsync()
	{
		List<User> users = _userManager.Users.ToList();
		List<UserResponseDto> response = _mapper.Map<List<UserResponseDto>>(users);
		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);

	}

	public async Task<DataResult<UserResponseDto>> GetByIdAsync(string id)
	{
		User? user  = await _userManager.FindByIdAsync(id);
		if (user == null) return ResultFactory.Failure<UserResponseDto>(
			null,
			message: "Not Found",
			statusCode: System.Net.HttpStatusCode.NotFound);

		UserResponseDto response = _mapper.Map<UserResponseDto>(user);
		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}
}
