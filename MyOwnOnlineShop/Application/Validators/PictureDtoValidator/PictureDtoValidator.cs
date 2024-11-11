using Application.Dto;
using FluentValidation;

namespace Application.Validators.PictureDtoValidator;
public class PictureDtoValidator : AbstractValidator<PictureDto>
{
    public PictureDtoValidator()
    {
        #region Name

        RuleFor(x => x.Name).NotEmpty().WithMessage("Picture field cannot be empty.");
        RuleFor(x => x.Name).Length(3, 100).WithMessage("Picture name must be between 3 and 100 characters long");

        #endregion Name

        #region Image

        RuleFor(x => x.Image).NotEmpty().WithMessage("Image field can not have an empty Image.");

        #endregion Image
    }
}