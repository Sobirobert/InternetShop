using Domain.Entities;
using Domain.Enums;

namespace Infrastructure.Builders;

public class ProductBuilder
{
    private int id;
    private string title;
    private string shortDescription;
    private string longDescription;
    private int amount;
    private string details;
    private int yearOfProduction;
    private double price;
    private bool isProductOfTheWeek;
    private TypeProduct type;
    private Category categoryOfProduct;
    private int categoryId;
    private ICollection<Order> orders;
    private ICollection<Picture> pictures;
    private ICollection<Attachment> attachments;

    public ProductBuilder SetId(int id)
    {
        this.id = id;
        return this;
    }

    public ProductBuilder SetTitle(string title)
    {
        this.title = title;
        return this;
    }

    public ProductBuilder SetShortDescription(string shortDescription)
    {
        this.shortDescription = shortDescription;
        return this;
    }

    public ProductBuilder SetAmount(int amount)
    {
        this.amount = amount;
        return this;
    }

    public ProductBuilder SetDetails(string details)
    {
        this.details = details;
        return this;
    }

    public ProductBuilder SetYearOfProduction(int yearOfProduction)
    {
        this.yearOfProduction = yearOfProduction;
        return this;
    }

    public ProductBuilder SetPrice(double price)
    {
        this.price = price;
        return this;
    }

    public ProductBuilder SetProductOfTheWeek(bool isProductOfTheWeek)
    {
        this.isProductOfTheWeek = isProductOfTheWeek;
        return this;
    }

    public ProductBuilder SetType(TypeProduct type)
    {
        this.type = type;
        return this;
    }

    public ProductBuilder SetcategoryOfProduct(Category category)
    {
        this.categoryOfProduct = category;
        this.categoryId = category.Id;
        return this;
    }

    public ProductBuilder SetOrder(ICollection<Order> orders)
    {
        this.orders = orders;
        return this;
    }

    public ProductBuilder SetPictures(ICollection<Picture> pictures)
    {
        this.pictures = pictures;
        return this;
    }
    public ProductBuilder SetAttachments(ICollection<Attachment> attachments)
    {
        this.attachments = attachments;
        return this;
    }

    public Product Build()
    {
        var product = new Product(
               Id: id, 
               Title: title, 
               ShortDescription: shortDescription, 
               LongDescription: longDescription, 
               Amount: amount, 
               Details: details, 
               YearOfProduction: yearOfProduction, 
               Price: price, 
               IsProductOfTheWeek: isProductOfTheWeek,
               TypeOfProduct: type
        ) with
        {
            Category = categoryOfProduct,
            CategoryId = categoryId,
            Orders = orders ?? new List<Order>(),
            Pictures = pictures ?? new List<Picture>(),
            Attachments = attachments ?? new List<Attachment>(),
        };

        return product;
    }
}
