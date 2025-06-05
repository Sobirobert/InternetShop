using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;
[Table("Attachments")]
public record Attachment(int Id, string Name, string Path, int UserId, ICollection<Product> Products)