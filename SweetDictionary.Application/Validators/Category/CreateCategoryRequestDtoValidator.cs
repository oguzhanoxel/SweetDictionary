using FluentValidation;
using SweetDictionary.Domain.Dtos.Category.RequestDtos;

namespace SweetDictionary.Application.Validators.Category;

public class CreateCategoryRequestDtoValidator : AbstractValidator<CreateCategoryRequestDto>
{
    public CreateCategoryRequestDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(2).MaximumLength(200);
    }
}