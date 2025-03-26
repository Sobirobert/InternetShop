using Application.Dto.AttachmentDto;
using FluentValidation;

namespace Application.Validators.AttachmentDtoValidator;

public class DownloadAttachmentDtoValidator : AbstractValidator<DownloadAttachmentDto>
{
    public DownloadAttachmentDtoValidator()
    {
        Include(new AttachmentDtoValidator());

        RuleFor(d => d.Content)
            .NotEmpty().WithMessage("Attachment content is required")
            .Must(content => content != null && content.Length > 0)
            .WithMessage("Attachment content cannot be empty");
    }
}
