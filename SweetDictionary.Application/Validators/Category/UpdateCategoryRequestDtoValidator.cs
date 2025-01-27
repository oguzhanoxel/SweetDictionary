using FluentValidation;
using SweetDictionary.Domain.Dtos.Category.RequestDtos;

namespace SweetDictionary.Application.Validators.Category;

public class UpdateCategoryRequestDtoValidator : AbstractValidator<UpdateCategoryRequestDto>
{
    public UpdateCategoryRequestDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(2).MaximumLength(200);
    }
}