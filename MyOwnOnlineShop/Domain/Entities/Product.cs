using Domain.Common;
using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;
[Table("Products")]
public record Product(
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
    int CategoryId)
    : AuditableEntity
{

    public ICollection<Order> Orders { get; set; }
    public ICollection<Picture> Pictures { get; set; }
    public ICollection<Attachment> Attachments { get; set; }
}