using Swashbuckle.AspNetCore.Filters;
using WebAPI.Models;

namespace WebAPI.SwaggerExamples.Requests;
public class UpdateCategoryModelExample : IExamplesProvider<UpdateCategoryModel>
{
    public UpdateCategoryModel GetExamples()
    {
        return new UpdateCategoryModel
        {
            Id = 1,
            CategoryName = "AGD",
            Description = "Nowy Opis"
        };
    }
}
