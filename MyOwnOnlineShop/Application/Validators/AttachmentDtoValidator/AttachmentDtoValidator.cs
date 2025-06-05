using Application.Dto.AttachmentsDto;
using FluentValidation;

namespace Application.Validators.AttachmentDtoValidator;
public class AttachmentDtoValidator : AbstractValidator<AttachmentDto>
{
    public AttachmentDtoValidator()
    {
        RuleFor(a => a.Id)
            .NotEmpty().WithMessage("Attachment ID is required");

        RuleFor(a => a.Name)
            .NotEmpty().WithMessage("Attachment name is required")
            .MaximumLength(100).WithMessage("Attachment name cannot exceed 100 characters");

        RuleFor(a => a.UserId)
            .NotEmpty().WithMessage("User ID is required")
            .GreaterThan(0).WithMessage("User ID must be greater than 0");
    }
}