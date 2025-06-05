using Domain.Entities;
using Xunit;

namespace xUnitTests.Entity;

public class PictureTests
{
    [Fact]
    public void Picture_Properties_SetAndGetCorrectly()
    {
        // Arrange
        var imageBytes = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
        var picture = new Picture
        {
            Id = 1,
            Name = "ProductImage",
            Image = imageBytes,
            Main = true
        };

        // Act & Assert
        Assert.Equal(1, picture.Id);
        Assert.Equal("ProductImage", picture.Name);
        Assert.Equal(imageBytes, picture.Image);
        Assert.True(picture.Main);
    }

    [Fact]
    public void Picture_ProductsCollection_CanBeInitialized()
    {
        // Arrange
        var picture = new Picture
        {
            Id = 1,
            Name = "ProductImage",
            Image = new byte[] { 0x20, 0x20, 0x20 },
            Main = true,
            Products = new List<Product>()
        };

        // Act & Assert
        Assert.NotNull(picture.Products);
        Assert.Empty(picture.Products);
    }

}
