using Domain.Entities;
using Domain.Enums;
using Xunit;

namespace xUnitTests.Entity;

public class OrderTests
{
    [Fact]
    public void Order_Properties_SetAndGetCorrectly()
    {
        // Arrange
        var order = new Order
        {
            OrderId = 1,
            ShippingStatus = ShippingStatus.Sent,
            PaymentStatus = PaymentStatus.Paid,
            TotalPrice = 150.50,
            FirstName = "Jan",
            LastName = "Kowalski",
            AddressLine1 = "ul. Testowa 1",
            AddressLine2 = "Mieszkanie 10",
            ZipCode = "00-001",
            City = "Warszawa",
            State = "Mazowieckie",
            Country = "Polska",
            PhoneNumber = "123456789",
            Email = "jan.kowalski@example.com",
            OrderTotal = 150.50,
            OrderPlaced = DateTime.Now
        };

        // Act & Assert
        Assert.Equal(1, order.OrderId);
        Assert.Equal(ShippingStatus.Sent, order.ShippingStatus);
        Assert.Equal(PaymentStatus.Paid, order.PaymentStatus);
        Assert.Equal(150.50, order.TotalPrice);
        Assert.Equal("Jan", order.FirstName);
        Assert.Equal("Kowalski", order.LastName);
        Assert.Equal("ul. Testowa 1", order.AddressLine1);
        Assert.Equal("Mieszkanie 10", order.AddressLine2);
        Assert.Equal("00-001", order.ZipCode);
        Assert.Equal("Warszawa", order.City);
        Assert.Equal("Mazowieckie", order.State);
        Assert.Equal("Polska", order.Country);
        Assert.Equal("123456789", order.PhoneNumber);
        Assert.Equal("jan.kowalski@example.com", order.Email);
        Assert.Equal(150.50, order.OrderTotal);
    }

    [Fact]
    public void Order_ShoppingCardsItems_CanBeInitializedAndModified()
    {
        // Arrange
        var order = new Order
        {
            OrderId = 1,
            ShoppingCardsItems = new List<OrderItem>()
        };

        var item1 = new OrderItem
        {
            OrderItemId = 1,
            ItemName = "Laptop",
            ProductId = 101,
            OrderId = 1,
            Amount = 1,
            Price = 2500.00
        };

        var item2 = new OrderItem
        {
            OrderItemId = 2,
            ItemName = "Mouse",
            ProductId = 102,
            OrderId = 1,
            Amount = 2,
            Price = 50.00
        };

        // Act
        order.ShoppingCardsItems.Add(item1);
        order.ShoppingCardsItems.Add(item2);

        // Assert
        Assert.Equal(2, order.ShoppingCardsItems.Count);
        Assert.Contains(item1, order.ShoppingCardsItems);
        Assert.Contains(item2, order.ShoppingCardsItems);
    }
}

public class OrderItemTests
{
    [Fact]
    public void OrderItem_Properties_SetAndGetCorrectly()
    {
        // Arrange
        var orderItem = new OrderItem
        {
            OrderItemId = 1,
            ItemName = "Laptop Dell XPS 13",
            ProductId = 101,
            OrderId = 1001,
            Amount = 1,
            Price = 4999.99
        };

        // Act & Assert
        Assert.Equal(1, orderItem.OrderItemId);
        Assert.Equal("Laptop Dell XPS 13", orderItem.ItemName);
        Assert.Equal(101, orderItem.ProductId);
        Assert.Equal(1001, orderItem.OrderId);
        Assert.Equal(1, orderItem.Amount);
        Assert.Equal(4999.99, orderItem.Price);
    }

    [Fact]
    public void OrderItem_AuditableEntityProperties_SetAndGetCorrectly()
    {
        // Arrange
        var createdDate = DateTime.Now.AddDays(-5);
        var modifiedDate = DateTime.Now;

        var orderItem = new OrderItem
        {
            CreatedBy = "CustomerUser",
            Created = createdDate,
            LastModifiedBy = "AdminUser",
            LastModified = modifiedDate
        };

        // Act & Assert
        Assert.Equal("CustomerUser", orderItem.CreatedBy);
        Assert.Equal(createdDate, orderItem.Created);
        Assert.Equal("AdminUser", orderItem.LastModifiedBy);
        Assert.Equal(modifiedDate, orderItem.LastModified);
    }
}
