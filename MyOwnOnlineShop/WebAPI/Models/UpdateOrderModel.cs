using Application.Dto.OrderDto;

namespace WebAPI.Models;
public class UpdateOrderModel
{
    public int OrderId { get; set; }
    public List<OrderItemDto> OrderItems { get; set; }
    public string Messenge1 { get; set; }
    public int ShippingStatus { get; set; }
    public string Messenge2 { get; set; }
    public int PaymentStatus { get; set; }
}
