using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;
[Table("Category")]
public class Category : AuditableEntity
{
    [Key]
    public int Id { get; set; }

    [MaxLength(100)]
    [Required]
    public string CategoryName { get; set; }

    [MaxLength(1000)]
    [Required]
    public string Description { get; set; }

    public int TotalRecords { get; set; }
}