
namespace Domain.Entities;

public class ShoppingCartItem
{
    public int ShoppingCartId { get; set; }
    public int ShoppingCartItemId { get; set; }
    public List<int> ProductsId { get; set; }
    public int Amount { get; set; }
    
}
