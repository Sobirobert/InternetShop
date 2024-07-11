using Swashbuckle.AspNetCore.Filters;
using WebAPI.Wrappers;

namespace WebAPI.SwaggerExamples.Responses.CategoryResponses;

public class CategoryResponseStatus200Example : IExamplesProvider<CategoryResponseStatus200>
{
    public CategoryResponseStatus200 GetExamples()
    {
        return new CategoryResponseStatus200
        {
            Succeeded = true,
            Message = "Well come Admin!"
        };
    }

}
public class CategoryResponseStatus200 : Response
{ }