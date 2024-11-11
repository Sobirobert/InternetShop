using Application.Dto;
using FluentValidation;

namespace Application.Validators.ProductDto;
public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductDtoValidator()
    {
        #region Title

        RuleFor(x => x.Title).NotEmpty().WithMessage("Product title field cannot be empty.");
        RuleFor(x => x.Title).Length(3, 100).WithMessage("Product title must be between 3 and 100 characters long.");

        #endregion Title

        #region DescriptionOfProduct

        RuleFor(x => x.ShortDescription).NotEmpty().WithMessage("Short description field cannot be empty.");
        RuleFor(x => x.ShortDescription).Length(3, 1500).WithMessage("Short description must be between 3 and 2500 characters long");

        #endregion DescriptionOfProduct

        #region LongDescriptionOfProduct

        RuleFor(x => x.LongDescription).NotEmpty().WithMessage("Long description field cannot be empty.");
        RuleFor(x => x.LongDescription).Length(3, 5000).WithMessage("Long description must be between 3 and 2500 characters long.");

        #endregion LongDescriptionOfProduct

        #region Price

        RuleFor(x => x.Price).NotEmpty().WithMessage("Price field cannot be empty.");

        #endregion Price

        #region Type

        RuleFor(x => x.Type).NotEmpty().WithMessage("Type field cannot be empty.");

        #endregion Type

        #region Amount

        RuleFor(x => x.Amount).NotEmpty().WithMessage("Amount field cannot be empty.");

        #endregion Amount

        #region CategoryId

        RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Category id field cannot be empty.");

        #endregion CategoryId
    }
}