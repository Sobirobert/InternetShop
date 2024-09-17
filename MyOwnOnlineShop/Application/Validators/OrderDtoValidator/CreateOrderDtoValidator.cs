using Application.Dto.AttachmentDto;
using Application.Dto.OrderDto;
using FluentValidation;

namespace Application.Validators.OrderDtoValidator
{
    public class CreateOrderDtoValidator : AbstractValidator<OrderDto>
    {
        public CreateOrderDtoValidator()
        {
            #region FirstName

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Order can not have an empty Name.");
            RuleFor(x => x.FirstName).Length(3, 100).WithMessage("The Name must be between 3 and 100 characters long");

            #endregion FirstName

            #region LastName
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Order can not have an empty Name.");
            RuleFor(x => x.LastName).Length(3, 100).WithMessage("The Name must be between 3 and 100 characters long");
            #endregion LastName

            #region AddressLine1
            RuleFor(x => x.AddressLine1).NotEmpty().WithMessage("Order can not have an empty Name.");
            RuleFor(x => x.AddressLine1).Length(3, 100).WithMessage("The Name must be between 3 and 100 characters long");
            #endregion AddressLine1

            #region ZipCode
            RuleFor(x => x.ZipCode).NotEmpty().WithMessage("Order can not have an empty Name.");
            RuleFor(x => x.ZipCode).Length(5, 5).WithMessage("The Name must be between 3 and 100 characters long");
            #endregion ZipCode

            #region City
            RuleFor(x => x.City).NotEmpty().WithMessage("Order can not have an empty Name.");
            RuleFor(x => x.City).Length(3, 100).WithMessage("The Name must be between 3 and 100 characters long");
            #endregion City

            #region State
            RuleFor(x => x.State).NotEmpty().WithMessage("Order can not have an empty Name.");
            RuleFor(x => x.State).Length(3, 100).WithMessage("The Name must be between 3 and 100 characters long");
            #endregion State

            #region Country
            RuleFor(x => x.Country).NotEmpty().WithMessage("Order can not have an empty Name.");
            RuleFor(x => x.Country).Length(3, 100).WithMessage("The Name must be between 3 and 100 characters long");
            #endregion Country

            #region PhoneNumber
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Order can not have an empty Name.");
            RuleFor(x => x.PhoneNumber).Length(3, 12).WithMessage("The Name must be between 3 and 100 characters long");
            #endregion PhoneNumber

            #region Email
            RuleFor(x => x.Email).NotEmpty().WithMessage("Order can not have an empty Name.");
            RuleFor(x => x.Email).Length(3, 12).WithMessage("The Name must be between 3 and 100 characters long");
            #endregion Email
        }
    }
}
