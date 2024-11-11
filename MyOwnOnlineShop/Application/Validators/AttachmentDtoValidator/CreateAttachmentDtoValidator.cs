using Application.Dto.AttachmentDto;
using FluentValidation;

namespace Application.Validators.AttachmentDtoValidator;
public class CreateAttachmentDtoValidator : AbstractValidator<AttachmentDto>
{
    public CreateAttachmentDtoValidator()
    {
        #region Name

        RuleFor(x => x.Name).NotEmpty().WithMessage("The attachment name cannot be empty.");
        RuleFor(x => x.Name).Length(3, 100).WithMessage("The attachment name must be between 3 and 100 characters long.");

        #endregion Name
    }
}