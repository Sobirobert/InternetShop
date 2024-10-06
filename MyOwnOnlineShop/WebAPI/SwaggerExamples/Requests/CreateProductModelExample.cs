using Domain.Enums;
using Swashbuckle.AspNetCore.Filters;
using WebAPI.Models;

namespace WebAPI.SwaggerExamples.Requests
{
    public class CreateProductModelExample : IExamplesProvider<CreateProductModel>
    {
        public CreateProductModel GetExamples()
        {
            return new CreateProductModel
            {
                Title = "Suszarka do włosów",
                ShortDescription = "Podręczna suszarka do włosów. Zmieści się do każdej walizki",
                LongDescription = "Nasza suszarka do włosów wyróżnia mały rozmiar. Składana roczka zmniejsza jej powierzchnię. Sprawdź!! Prawdziwa okazja.",
                Details = "Rodzaj = elektryczne, Możliwość składani rączki, Tryb ciepły i zimny",
                YearOfProduction = 2024,
                Amount = 100,
                Price = 29.99,
                IsProductOfTheWeek = true,
                Type = (TypeProduct)1,
                CategoryId = 1
            };
        }
    }
}
