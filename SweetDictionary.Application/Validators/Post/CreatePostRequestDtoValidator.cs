using FluentValidation;
using SweetDictionary.Domain.Dtos.Post.RequestDtos;

namespace SweetDictionary.Application.Validators.Post;

public class CreatePostRequestDtoValidator : AbstractValidator<CreatePostRequestDto>
{
    public CreatePostRequestDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(100);
        RuleFor(x => x.Content)
            .NotEmpty()
            .MinimumLength(10)
            .MaximumLength(2000);
        RuleFor(x => x.CategoryId)
            .NotEmpty();
        RuleFor(x => x.AuthorId)
            .NotEmpty();
    }
}