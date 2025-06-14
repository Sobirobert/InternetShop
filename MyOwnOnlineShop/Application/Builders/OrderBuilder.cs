using Domain.Entities;
using Domain.Enums;
using static Domain.Entities.Order;
using Order = Domain.Entities.Order;

namespace Infrastructure.Builders;

public class OrderBuilder
{
    private int id;
    private Guid publicId;
    private ShippingStatus shippingStatus;
    private PaymentStatus paymentStatus;
    private double totalPrice;
    private ICollection<Product> itemList;
    private DateTime orderPlaced;
    private Adress adress;
    private Contact contact;
    private PersonalInfo personalInfo;
    //private IStrategy _strategy;

    public OrderBuilder SetId(int id)
    {
        this.id = id;
        return this;
    }

    public OrderBuilder SetPublicId()
    {
        this.publicId = Guid.NewGuid();
        return this;
    }

    public OrderBuilder SetShippingStatus(ShippingStatus shippingStatus)
    {
        this.shippingStatus = shippingStatus;
        return this;
    }

    public OrderBuilder SetPaymentStatus(PaymentStatus paymentStatus)
    {
        this.paymentStatus = paymentStatus;
        return this;
    }

    public OrderBuilder SetTotalPrice(ICollection<Product> shoppingCardsItems)
    {
        double totalPrice = 0;
        foreach (var item in shoppingCardsItems)
        {
            totalPrice += item.Price;
        }
        this.totalPrice = totalPrice;
        return this;
    }

    public OrderBuilder SetShoppingCardsItems(ICollection<Product> itemList)
    {
        this.itemList = itemList;
        return this;
    }

    public OrderBuilder SetOrderPlaced()
    {
        this.orderPlaced = DateTime.Now;
        return this;
    }

    public OrderBuilder SetAdress(Adress adress)
    {
        this.adress = adress;
        return this;
    }

    public OrderBuilder SetContact(Contact contact)
    {
        this.contact = contact;
        return this;
    }

    public OrderBuilder SetPersonalInfo(PersonalInfo personalInfo)
    {
        this.personalInfo = personalInfo;
        return this;
    }

    //public OrderFactory UseStrategy(IStrategy strategy)
    //{
    //    this._strategy = strategy;
    //    return this;
    //}
    public Order Build()
    {
        var order = new Order(
            OrderId: id,
            PublicId: publicId,
            ShippingStatus: shippingStatus,
            PaymentStatus: paymentStatus,
            TotalPrice: totalPrice,
            OrderPlaced: orderPlaced
        ) with
        {
            DeliveryAddress = adress,
            CustomerContact = contact,
            CustomerInfo = personalInfo,
            ProductsList = itemList ?? new List<Product>()
        };

        return order;
    }
}
