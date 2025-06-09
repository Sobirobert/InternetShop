using Domain.Entities;
using FluentValidation;

namespace Domain.Validation;

public class AttachmentValidator : AbstractValidator<Attachment>
{
    public AttachmentValidator()
    {
        RuleFor(a => a.Id)
            .NotEmpty().WithMessage("Attachment ID is required");

        RuleFor(a => a.Name)
            .NotEmpty().WithMessage("Attachment name is required")
            .MaximumLength(100).WithMessage("Attachment name cannot exceed 100 characters");

        RuleFor(a => a.Path)
            .NotEmpty().WithMessage("Attachment path is required")
            .MaximumLength(200).WithMessage("Attachment path cannot exceed 200 characters");

    }
}
