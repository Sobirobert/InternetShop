using Domain.Entities;
using Xunit;

namespace xUnitTests.Entity;

public class CategoryTest
{
    [Fact]
    public void Category_Properties_SetAndGetCorrectly()
    {
        // Arrange
        var category = new Category
        {
            Id = 1,
            CategoryName = "Electronics",
            Description = "Electronic devices and gadgets",
            TotalRecords = 15
        };

        // Act & Assert
        Assert.Equal(1, category.Id);
        Assert.Equal("Electronics", category.CategoryName);
        Assert.Equal("Electronic devices and gadgets", category.Description);
        Assert.Equal(15, category.TotalRecords);
    }

    [Fact]
    public void Category_AuditableEntityProperties_SetAndGetCorrectly()
    {
        // Arrange
        var createdDate = DateTime.Now.AddDays(-10);
        var modifiedDate = DateTime.Now;

        var category = new Category
        {
            CreatedBy = "TestUser",
            Created = createdDate,
            LastModifiedBy = "AdminUser",
            LastModified = modifiedDate
        };

        // Act & Assert
        Assert.Equal("TestUser", category.CreatedBy);
        Assert.Equal(createdDate, category.Created);
        Assert.Equal("AdminUser", category.LastModifiedBy);
        Assert.Equal(modifiedDate, category.LastModified);
    }
}
