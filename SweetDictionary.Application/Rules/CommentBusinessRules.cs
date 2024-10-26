using Core.Exceptions;
using SweetDictionary.Domain.Entities;
using SweetDictionary.Persistence.Repositories.Abstracts;

namespace SweetDictionary.Application.Rules;

public class CommentBusinessRules
{
	private readonly ICommentRepository _commentRepository;

	public CommentBusinessRules(ICommentRepository commentRepository)
	{
		_commentRepository = commentRepository;
	}

	public void CommentShouldExistWhenRequested(Guid id)
	{
		Comment? comment = _commentRepository.Get(x => x.Id == id);
		if (comment is null) throw new BusinessException("Not Found");
	}
}
