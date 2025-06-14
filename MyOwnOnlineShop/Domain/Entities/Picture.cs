namespace Domain.Entities;
public record Picture (int Id, string Name, byte[] Image, bool Main)
{
    public ICollection<Product> Products { get; set; }
}