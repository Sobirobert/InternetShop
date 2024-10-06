namespace WebAPI.Models
{
    public class UpdateOrderItemModel
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
    }
}
