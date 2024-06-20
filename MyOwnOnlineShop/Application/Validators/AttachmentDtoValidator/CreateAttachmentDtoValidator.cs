
using Application.Dto.AttachmentDto;
using FluentValidation;

namespace Application.Validators.AttachmentDtoValidator;

public class CreateAttachmentDtoValidator : AbstractValidator<AttachmentDto>
{
    public CreateAttachmentDtoValidator()
    {

        #region Name

        RuleFor(x => x.Name).NotEmpty().WithMessage("Attachment can not have an empty Name.");
        RuleFor(x => x.Name).Length(3, 100).WithMessage("The Name must be between 3 and 100 characters long");

        #endregion Name

    }
}
