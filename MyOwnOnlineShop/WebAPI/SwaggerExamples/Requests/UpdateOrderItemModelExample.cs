using Swashbuckle.AspNetCore.Filters;
using WebAPI.Models;

namespace WebAPI.SwaggerExamples.Requests;
public class UpdateOrderItemModelExample : IExamplesProvider<UpdateOrderItemModel>
{
    public UpdateOrderItemModel GetExamples()
    {
        return new UpdateOrderItemModel
        {
           OrderItemId = 1,
           OrderId = 2,
           Amount = 1,
           Price = 1.20
        };
    }
}
