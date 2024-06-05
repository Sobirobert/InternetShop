using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities;

//[Table("Attachments")]
//public class Attachment
//{
//    [Key]
//    public int Id { get; set; }

//    [Required]
//    [MaxLength(100)]
//    [NotNull]
//    public string Name { get; set; }

//    [Required]
//    [MaxLength(200)]
//    [NotNull]
//    public string Path { get; set; }

//    public ICollection<Product> Products { get; set; }
//}