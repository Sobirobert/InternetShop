using Swashbuckle.AspNetCore.Filters;
using WebAPI.Wrappers;

namespace WebAPI.SwaggerExamples.Responses.CategoryResponses;
public class CategoryCreateResponseStatus500Example : IExamplesProvider<CategoryCreateResponseStatus500>
{
    public CategoryCreateResponseStatus500 GetExamples()
    {
        return new CategoryCreateResponseStatus500
        {
            Succeeded = false,
            Message = "Category already exists!"
        };
    }
}

public class CategoryCreateResponseStatus500 : Response
{ }