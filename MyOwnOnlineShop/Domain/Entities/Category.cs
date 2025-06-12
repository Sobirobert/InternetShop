using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;
public record Category(int Id, string CategoryName, string Description, int TotalRecords) 
    : AuditableEntity
{
    public ICollection<Product> Products { get; set; }
}