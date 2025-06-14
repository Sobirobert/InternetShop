namespace Domain.Entities;
public record Attachment(int Id, string Name, string Path)
{
    public ICollection<Product> Products { get; set; }
}