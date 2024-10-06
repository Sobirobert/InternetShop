using Application.Dto.OrderDto;
using Swashbuckle.AspNetCore.Filters;
using WebAPI.Models;

namespace WebAPI.SwaggerExamples.Requests
{
    public class UpdateOrderModelExample : IExamplesProvider<UpdateOrderModel>
    {
        public UpdateOrderModel GetExamples()
        {
            return new UpdateOrderModel
            {
                OrderId = 1,
                Messenge1 = "Select a number from 1 to 3. Unsent = 1, Sent = 2, Returned = 3",
                ShippingStatus = 1,
                Messenge2 = "Select a number from 1 to 4. Unpaid = 1, Paid = 2, CashOnDelivery = 3, InInstallments = 4",
                PaymentStatus = 2,  
            };
        }
    }
}
