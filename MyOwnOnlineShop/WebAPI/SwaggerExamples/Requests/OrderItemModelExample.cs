using Swashbuckle.AspNetCore.Filters;
using WebAPI.Models;

namespace WebAPI.SwaggerExamples.Requests;
public class OrderItemModelExample : IExamplesProvider<OrderItemModel>
{
    public OrderItemModel GetExamples()
    {
        return new OrderItemModel
        {
            orderId = 1,
            productId = 1,
            amount = 3,
        };
    }
}
