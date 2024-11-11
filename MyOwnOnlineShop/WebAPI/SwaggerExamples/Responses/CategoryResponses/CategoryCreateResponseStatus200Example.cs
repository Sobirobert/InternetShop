using Swashbuckle.AspNetCore.Filters;
using WebAPI.Wrappers;

namespace WebAPI.SwaggerExamples.Responses.CategoryResponses;
public class CategoryCreateResponseStatus200Example : IExamplesProvider<CategoryCreateResponseStatus200>
{
    public CategoryCreateResponseStatus200 GetExamples()
    {
        return new CategoryCreateResponseStatus200
        {
            Succeeded = true,
            Message = "Category Created successfully! Well done"
        };
    }
}

public class CategoryCreateResponseStatus200 : Response
{ }