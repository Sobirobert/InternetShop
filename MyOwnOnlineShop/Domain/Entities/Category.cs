using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

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

    public int totalRecords { get; set; }
}