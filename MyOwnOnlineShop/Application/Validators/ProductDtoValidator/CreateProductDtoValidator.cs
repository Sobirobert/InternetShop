using Application.Dto;
using FluentValidation;

namespace Application.Validators.ProductDto;

public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductDtoValidator()
    {
        #region Title

        RuleFor(x => x.Title).NotEmpty().WithMessage("Product can not have an empty title.");
        RuleFor(x => x.Title).Length(3, 100).WithMessage("The title must be between 3 and 100 characters long");

        #endregion Title

        #region DescriptionOfProduct

        RuleFor(x => x.ShortDescription).NotEmpty().WithMessage("Product can not have an empty Description.");
        RuleFor(x => x.ShortDescription).Length(3, 1500).WithMessage("The description must be between 3 and 2500 characters long");

        #endregion DescriptionOfProduct

        #region LongDescriptionOfProduct

        RuleFor(x => x.LongDescription).NotEmpty().WithMessage("Product can not have an empty Description.");
        RuleFor(x => x.LongDescription).Length(3, 5000).WithMessage("The description must be between 3 and 2500 characters long");

        #endregion LongDescriptionOfProduct

        #region Price

        RuleFor(x => x.Price).NotEmpty().WithMessage("Product can not have an empty Price.");

        #endregion Price

        #region Type

        RuleFor(x => x.Type).NotEmpty().WithMessage("Product can not have an empty Type.");

        #endregion Type

        #region Amount

        RuleFor(x => x.Amount).NotEmpty().WithMessage("Product can not have an empty Type.");

        #endregion Amount

        #region CategoryId

        RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Product can not have an empty Type.");

        #endregion CategoryId
    }
}