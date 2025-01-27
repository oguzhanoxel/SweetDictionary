using FluentValidation;
using SweetDictionary.Domain.Dtos.Post.RequestDtos;

namespace SweetDictionary.Application.Validators.Post;

public class UpdatePostRequestDtoValidator : AbstractValidator<UpdatePostRequestDto>
{
    public UpdatePostRequestDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(100);
        RuleFor(x => x.Content)
            .NotEmpty()
            .MinimumLength(10)
            .MaximumLength(2000);
    }
}