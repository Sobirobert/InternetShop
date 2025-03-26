using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;
[Table("Category")]
public class Category : AuditableEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string CategoryName { get; set; }

    [Required]
    public string Description { get; set; }

    public int TotalRecords { get; set; }
}