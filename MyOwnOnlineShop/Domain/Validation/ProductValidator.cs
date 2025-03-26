using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;

namespace Domain.Validation;

public class ProductValidator : IDomainValidator<Product>
{
    public ValidationResult Validate(Product product)
    {
        {
            var result = new ValidationResult();

            if (string.IsNullOrWhiteSpace(product.Title))
                result.AddError("Product title is required");

            if (product.Title?.Length > 100)
                result.AddError("Product title cannot exceed 100 characters");

            if (string.IsNullOrWhiteSpace(product.ShortDescription))
                result.AddError("Short description is required");

            if (product.ShortDescription?.Length > 250)
                result.AddError("Short description cannot exceed 250 characters");

            if (string.IsNullOrWhiteSpace(product.LongDescription))
                result.AddError("Long description is required");

            if (product.LongDescription?.Length > 4000)
                result.AddError("Long description cannot exceed 4000 characters");

            if (product.Amount < 0)
                result.AddError("Amount cannot be negative");

            if (string.IsNullOrWhiteSpace(product.Details))
                result.AddError("Product details are required");

            if (product.Details?.Length > 2000)
                result.AddError("Product details cannot exceed 2000 characters");

            if (product.YearOfProduction < 1900)
                result.AddError("Year of production must be greater than 1900");

            if (product.YearOfProduction > DateTime.Now.Year)
                result.AddError($"Year of production cannot be later than the current year ({DateTime.Now.Year})");

            if (product.Price <= 0)
                result.AddError("Price must be greater than 0");

            if (product.Price >= 1000000)
                result.AddError("Price cannot exceed 1,000,000");

            if (!Enum.IsDefined(typeof(TypeProduct), product.Type))
                result.AddError("Invalid product type");

            if (product.CategoryId <= 0)
                result.AddError("Category ID must be greater than 0");

            if (product.Price > 10000 && product.Amount > 50)
                result.AddError("For products priced above 10,000, the maximum available quantity is 50 units");

            if (product.IsProductOfTheWeek)
            {
                if (product.Price >= 5000)
                    result.AddError("Products of the week cannot cost more than 5,000");

                if (product.Amount <= 5)
                    result.AddError("Product of the week must be available in quantities greater than 5 units");
            }

            return result;
        }
    }
}


