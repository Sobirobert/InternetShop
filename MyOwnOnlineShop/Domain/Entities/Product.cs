using Domain.Common;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;
[Table("Products")]
public record Product(
    DateTime Created, 
    string? CreatedBy, 
    DateTime? LastModified, 
    string? LastModifiedBy,  
    int Id, 
    string Title, 
    string ShortDescription, 
    string LongDescription,
    int Amount, string Details, 
    int YearOfProduction, 
    double Price, 
    bool IsProductOfTheWeek, 
    TypeProduct Type, 
    Category Category, 
    int CategoryId, 
    ICollection<Order> OrderItems,
    ICollection<Picture> Pictures, 
    ICollection<Attachment> Attachments) 
    : AuditableEntity(Created, CreatedBy, LastModified, LastModifiedBy);