using Swashbuckle.AspNetCore.Filters;
using WebAPI.Wrappers;

namespace WebAPI.SwaggerExamples.Responses.CategoryResponses;

public class CategoryResponseStatus500Example : IExamplesProvider<CategoryResponseStatus500>
{
    public CategoryResponseStatus500 GetExamples()
    {
        return new CategoryResponseStatus500
        {
            Succeeded = false,
            Message = "Please authorization."
        };
    }
}

public class CategoryResponseStatus500 : Response
{ }