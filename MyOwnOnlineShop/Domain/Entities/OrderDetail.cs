namespace Domain.Entities;

public class OrderDetail
{
    public int OrderDetailId { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public double Price { get; set; }
    public List<Product> ListOfProducts { get; set; }
    public Order Order { get; set; }
}