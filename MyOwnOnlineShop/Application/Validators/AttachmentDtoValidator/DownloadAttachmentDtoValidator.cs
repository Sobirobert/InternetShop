using Application.Dto.AttachmentsDto;
using FluentValidation;
using static Application.Dto.AttachmentsDto.AttachmentDto;

namespace Application.Validators.AttachmentDtoValidator;

public class DownloadAttachmentDtoValidator : AbstractValidator<DownloadAttachmentDto>
{
    public DownloadAttachmentDtoValidator()
    {

        RuleFor(d => d.Content)
            .NotEmpty().WithMessage("Attachment content is required")
            .Must(content => content != null && content.Length > 0)
            .WithMessage("Attachment content cannot be empty");
    }
}
