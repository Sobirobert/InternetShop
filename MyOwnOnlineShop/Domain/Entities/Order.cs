using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Order
{
    [BindNever]
    public int OrderId { get; set; }

    public List<OrderDetail> OrderDetails { get; set; }

    [Required(ErrorMessage = "Podaj imię")]
    [Display(Name = "Imię")]
    [StringLength(50)]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Podaj nazwisko")]
    [Display(Name = "Nazwisko")]
    [StringLength(50)]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Podaj adres")]
    [StringLength(100)]
    [Display(Name = "Adres 1")]
    public string AddressLine1 { get; set; }

    [Display(Name = "Adres 2")]
    public string AddressLine2 { get; set; }

    [Required(ErrorMessage = "Podaj kod pocztowy")]
    [Display(Name = "Kod pocztowy")]
    [StringLength(10, MinimumLength = 4)]
    public string ZipCode { get; set; }

    [Required(ErrorMessage = "Podaj miasto")]
    [StringLength(50)]
    [Display(Name = "Kod pocztowy")]
    public string City { get; set; }

    [StringLength(10)]
    [Display(Name = "Kod województwo")]
    public string State { get; set; }

    [Required(ErrorMessage = "Podaj kraj")]
    [StringLength(50)]
    [Display(Name = "Kraj")]
    public string Country { get; set; }

    [Required(ErrorMessage = "Podaj numer telefonu")]
    [StringLength(25)]
    [DataType(DataType.PhoneNumber)]
    [Display(Name = "Numer telefonu")]
    public string PhoneNumber { get; set; }

    [Required]
    [StringLength(50)]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
        ErrorMessage = "Email jest w złym formacie")]
    public string Email { get; set; }

    [BindNever]
    [ScaffoldColumn(false)]
    public double OrderTotal { get; set; }

    [BindNever]
    [ScaffoldColumn(false)]
    public DateTime OrderPlaced { get; set; }
}