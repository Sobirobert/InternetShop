using Domain.Common;
using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;
public record Product(
    int Id, 
    string Title, 
    string ShortDescription, 
    string LongDescription,
    int Amount, string Details, 
    int YearOfProduction, 
    double Price, 
    bool IsProductOfTheWeek, 
    TypeProduct Type)
    : AuditableEntity
{

    public Category Category { get; set; }
    public int CategoryId { get; set; }
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<Picture> Pictures { get; set; }
    public ICollection<Attachment> Attachments { get; set; }
}