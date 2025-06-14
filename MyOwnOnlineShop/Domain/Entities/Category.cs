using Domain.Common;

namespace Domain.Entities;
public record Category(int Id, string CategoryName, string Description, int TotalRecords) 
    : AuditableEntity
{
    public ICollection<Product> Products { get; set; }
}