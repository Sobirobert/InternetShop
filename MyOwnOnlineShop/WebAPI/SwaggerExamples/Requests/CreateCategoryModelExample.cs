using Swashbuckle.AspNetCore.Filters;
using WebAPI.Models;

namespace WebAPI.SwaggerExamples.Requests
{
    public class CreateCategoryModelExample : IExamplesProvider<CreateCategoryModel>
    {
        public CreateCategoryModel GetExamples()
        {
            return new CreateCategoryModel
            {
                CategoryName = "AGD",
                Description = "Urządzenia AGD róznych Firm. Wejdź sprawdż ! NISKA CENA !!"
            };
        }
    }
}
