namespace WebAPI.Models
{
    public class OrderItemModel
    {
        public int orderId {  get; set; }
        public int amount { get; set; }
        public int productId { get; set; }
    }
}
