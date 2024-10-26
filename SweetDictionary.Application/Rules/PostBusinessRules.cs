using Core.Exceptions;
using SweetDictionary.Domain.Entities;
using SweetDictionary.Persistence.Repositories.Abstracts;

namespace SweetDictionary.Application.Rules;

public class PostBusinessRules
{
	private readonly IPostRepository _postRepository;

	public PostBusinessRules(IPostRepository postRepository)
	{
		_postRepository = postRepository;
	}

	public void PostShouldExistWhenRequested(Guid id)
	{
		Post? post = _postRepository.Get(x => x.Id == id);
		if (post is null) throw new BusinessException("Not Found");
	}
}
