using Application.Dto.CategoryDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.CategoryDtoValidator
{
    public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryDtoValidator()
        {
            #region CategoryName

            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Category name can not have an empty title.");
            RuleFor(x => x.CategoryName).Length(3, 100).WithMessage("The Category name must be between 3 and 100 characters long");

            #endregion CategoryName

            #region Description

            RuleFor(x => x.Description).NotEmpty().WithMessage("The Description of a Category can not have an empty title.");
            RuleFor(x => x.Description).Length(3, 300).WithMessage("The Description of a Category name must be between 3 and 100 characters long");

            #endregion Description
        }
    }
}
