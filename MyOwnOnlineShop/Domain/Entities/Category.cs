using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;
[Table("Category")]
public record Category(int Id, string CategoryName, string Description, int TotalRecords, ICollection<Product> Products) 
    : AuditableEntity;