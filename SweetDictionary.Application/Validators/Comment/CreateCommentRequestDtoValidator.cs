using FluentValidation;
using SweetDictionary.Domain.Dtos.Comment.RequestDtos;

namespace SweetDictionary.Application.Validators.Comment;

public class CreateCommentRequestDtoValidator : AbstractValidator<CreateCommentRequestDto>
{
    public CreateCommentRequestDtoValidator()
    {
        RuleFor(x => x.Text).NotEmpty().MinimumLength(2).MaximumLength(500);
        RuleFor(x => x.PostId).NotEmpty();
        RuleFor(x => x.UserId).NotEmpty();
    }
}