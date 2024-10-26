using Core.Exceptions;
using Microsoft.AspNetCore.Identity;
using SweetDictionary.Domain.Entities;

namespace SweetDictionary.Application.Rules;

public class UserBusinessRules
{
	private readonly UserManager<User> _userManager;

	public UserBusinessRules(UserManager<User> userManager)
	{
		_userManager = userManager;
	}

	public async Task UserShouldExistWhenRequestedAsync(string id)
	{
		User? user = await _userManager.FindByIdAsync(id);
		if (user is null) throw new BusinessException("Not Found");
	}
}