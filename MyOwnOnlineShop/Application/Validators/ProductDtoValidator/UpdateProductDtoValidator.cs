using Application.Dto;
using FluentValidation;
namespace Application.Validators.ProductDto;

public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
{
    public UpdateProductDtoValidator()
    {
        #region Title

        RuleFor(x => x.Title).NotEmpty().WithMessage("Product can not have an empty title.");
        RuleFor(x => x.Title).Length(3, 100).WithMessage("The title must be between 3 and 100 characters long");

        #endregion Title

        #region DescriptionOfProduct

        //RuleFor(x => x.DescriptionOfProduct).NotEmpty().WithMessage("Product can not have an empty description.");
        //RuleFor(x => x.DescriptionOfProduct).Length(3, 2500).WithMessage("The description must be between 3 and 2500 characters long");

        #endregion DescriptionOfProduct

        #region Price

        RuleFor(x => x.Price).NotEmpty().WithMessage("Product can not have an empty Price.");

        #endregion Price
    }
}
