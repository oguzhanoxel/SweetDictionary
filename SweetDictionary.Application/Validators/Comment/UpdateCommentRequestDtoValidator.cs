using FluentValidation;
using SweetDictionary.Domain.Dtos.Comment.RequestDtos;

namespace SweetDictionary.Application.Validators.Comment;

public class UpdateCommentRequestDtoValidator : AbstractValidator<UpdateCommentRequestDto>
{
    public UpdateCommentRequestDtoValidator()
    {
        RuleFor(x => x.Text).NotEmpty().MinimumLength(2).MaximumLength(500);
    }
}