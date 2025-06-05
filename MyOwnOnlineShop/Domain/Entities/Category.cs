using Domain.Common;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;
[Table("Category")]
public record Category(int Id, string CategoryName, string Description, int TotalRecords, ICollection<Product> Products, 
    DateTime Created, string? CreatedBy, DateTime? LastModified, string? LastModifiedBy) 
    : AuditableEntity(Created, CreatedBy, LastModified, LastModifiedBy);