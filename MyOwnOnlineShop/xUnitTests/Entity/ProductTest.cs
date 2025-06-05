using Domain.Entities;
using Domain.Enums;
using Xunit;

namespace xUnitTests.Entity;

public class ProductTest
{
    [Fact]
    public void Product_Properties_SetAndGetCorrectly()
    {
        // Arrange
        var product = new Product
        {
            Id = 1,
            Title = "Laptop Dell XPS 15",
            ShortDescription = "Wydajny laptop dla profesjonalistów",
            LongDescription = "Szczegółowy opis laptopa...",
            Amount = 10,
            Details = "Procesor Intel i7, 16GB RAM, 1TB SSD",
            YearOfProduction = 2023,
            Price = 6999.99,
            IsProductOfTheWeek = true,
            Type = TypeProduct.New,
            CategoryId = 5
        };

        // Act & Assert
        Assert.Equal(1, product.Id);
        Assert.Equal("Laptop Dell XPS 15", product.Title);
        Assert.Equal("Wydajny laptop dla profesjonalistów", product.ShortDescription);
        Assert.Equal("Szczegółowy opis laptopa...", product.LongDescription);
        Assert.Equal(10, product.Amount);
        Assert.Equal("Procesor Intel i7, 16GB RAM, 1TB SSD", product.Details);
        Assert.Equal(2023, product.YearOfProduction);
        Assert.Equal(6999.99, product.Price);
        Assert.True(product.IsProductOfTheWeek);
        Assert.Equal(TypeProduct.New, product.Type);
        Assert.Equal(5, product.CategoryId);
    }

    [Fact]
    public void Product_CollectionProperties_CanBeInitialized()
    {
        // Arrange
        var product = new Product
        {
            Id = 1,
            Title = "Laptop Dell XPS 15",
            Pictures = new List<Picture>(),
            Attachments = new List<Attachment>()
        };

        var picture = new Picture
        {
            Id = 1,
            Name = "Front View",
            Image = new byte[] { 0x20, 0x20, 0x20 },
            Main = true
        };

        var attachment = new Attachment
        {
            Id = 1,
            Name = "User Manual",
            Path = "/files/manuals/dell-xps-15.pdf",
            UserId = 1
        };

        // Act
        product.Pictures.Add(picture);
        product.Attachments.Add(attachment);

        // Assert
        Assert.Single(product.Pictures);
        Assert.Single(product.Attachments);
        Assert.Contains(picture, product.Pictures);
        Assert.Contains(attachment, product.Attachments);
    }

    [Fact]
    public void Product_AuditableEntityProperties_SetAndGetCorrectly()
    {
        // Arrange
        var createdDate = DateTime.Now.AddDays(-30);
        var modifiedDate = DateTime.Now;

        var product = new Product
        {
            CreatedBy = "ProductManager",
            Created = createdDate,
            LastModifiedBy = "AdminUser",
            LastModified = modifiedDate
        };

        // Act & Assert
        Assert.Equal("ProductManager", product.CreatedBy);
        Assert.Equal(createdDate, product.Created);
        Assert.Equal("AdminUser", product.LastModifiedBy);
        Assert.Equal(modifiedDate, product.LastModified);
    }
}
