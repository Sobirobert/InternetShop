using Domain.Entities;
using Xunit;

namespace xUnitTests.Entity;

public class AttachmentTest
{
    [Fact]
    public void Attachment_Properties_SetAndGetCorrectly()
    {
        // Arrange
        var attachment = new Attachment
        {
            Id = 1,
            Name = "TestAttachment",
            Path = "/files/attachments/document.pdf",
            UserId = 10
        };

        // Act & Assert
        Assert.Equal(1, attachment.Id);
        Assert.Equal("TestAttachment", attachment.Name);
        Assert.Equal("/files/attachments/document.pdf", attachment.Path);
        Assert.Equal(10, attachment.UserId);
    }

    [Fact]
    public void Attachment_ProductsCollection_CanBeInitialized()
    {
        // Arrange
        var attachment = new Attachment
        {
            Id = 1,
            Name = "TestAttachment",
            Path = "/files/attachments/document.pdf",
            UserId = 10,
            Products = new List<Product>()
        };

        // Act & Assert
        Assert.NotNull(attachment.Products);
        Assert.Empty(attachment.Products);
    }
}
