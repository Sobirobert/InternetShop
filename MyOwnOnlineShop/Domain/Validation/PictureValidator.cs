using Domain.Entities;
using FluentValidation;

namespace Domain.Validation;
public class PictureValidator : AbstractValidator<Picture>
{
    public PictureValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("Picture Id is required");

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Picture name is required")
            .MaximumLength(100).WithMessage("Picture name cannot exceed 100 characters");

        RuleFor(p => p.Image)
            .NotEmpty().WithMessage("Picture image is required")
            .Must(image => image != null && image.Length > 0)
            .WithMessage("Picture image cannot be empty");

        RuleFor(p => p.Main)
            .NotNull().WithMessage("Main flag must be specified");
    }
}
