using Application.Dto.OrderDto;
using FluentValidation;

namespace Application.Validators.OrderDtoValidator;
public class CreateOrderDtoValidator : AbstractValidator<OrderDto>
{
    public CreateOrderDtoValidator()
    {
        #region FirstName
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("The first name field cannot be empty.");
        RuleFor(x => x.FirstName).Length(3, 100).WithMessage("The first name must be between 3 and 100 characters long.");
        #endregion FirstName

        #region LastName
        RuleFor(x => x.LastName).NotEmpty().WithMessage("The last name cannot be empty.");
        RuleFor(x => x.LastName).Length(3, 100).WithMessage("The last name must be between 3 and 100 characters long.");
        #endregion LastName

        #region AddressLine1
        RuleFor(x => x.AddressLine1).NotEmpty().WithMessage("The first address line field cannot be empty");
        RuleFor(x => x.AddressLine1).Length(3, 100).WithMessage("The first address line must be between 3 and 100 characters long!");
        #endregion AddressLine1

        #region ZipCode
        RuleFor(x => x.ZipCode).NotEmpty().WithMessage("The ZipCode field cannot be empty.");
        RuleFor(x => x.ZipCode).Length(5, 5).WithMessage("The ZipCode should be 5 characters long!");
        #endregion ZipCode

        #region City
        RuleFor(x => x.City).NotEmpty().WithMessage("The city field cannot be empty.");
        RuleFor(x => x.City).Length(3, 100).WithMessage("The city must be between 3 and 100 characters long!");
        #endregion City

        #region State
        RuleFor(x => x.State).NotEmpty().WithMessage("The state field cannot be empty.");
        RuleFor(x => x.State).Length(3, 100).WithMessage("The state must be between 3 and 100 characters long!");
        #endregion State

        #region Country
        RuleFor(x => x.Country).NotEmpty().WithMessage("The country field cannot be empty.");
        RuleFor(x => x.Country).Length(3, 100).WithMessage("The country must be between 3 and 100 characters long!");
        #endregion Country

        #region PhoneNumber
        RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("The phone number field cannot be empty.");
        RuleFor(x => x.PhoneNumber).Length(3, 12).WithMessage("The phone number must be between 3 and 100 characters long");
        #endregion PhoneNumber

        #region Email
        RuleFor(x => x.Email).NotEmpty().WithMessage("The email field cannot be empty.");
        RuleFor(x => x.Email).Length(3, 22).WithMessage("The email must be between 3 and 100 characters long");
        #endregion Email
    }
}
