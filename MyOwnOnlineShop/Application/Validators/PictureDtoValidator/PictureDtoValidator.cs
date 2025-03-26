using Application.Dto;
using FluentValidation;

namespace Application.Validators.PictureDtoValidator;
public class PictureDtoValidator : AbstractValidator<PictureDto>
{
    public PictureDtoValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("Picture ID is required");

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