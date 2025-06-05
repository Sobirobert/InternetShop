using Domain.Entities;
using Domain.Enums;
using StackExchange.Redis;
using static Domain.Entities.Order;
using Order = Domain.Entities.Order;

namespace Infrastructure.Facories;

public class OrderFactory
{
    private int id;
    private Guid publicId;
    private ShippingStatus shippingStatus;
    private PaymentStatus paymentStatus;
    private double totalPrice;
    private ICollection<Product> shoppingCardsItems;
    private DateTime orderPlaced;
    private Adress adress;
    private Contact contact;
    private PersonalInfo personalInfo;
    //private IStrategy _strategy;

    public OrderFactory SetId(int id)
    {
        this.id = id;
        return this;
    }

    public OrderFactory SetPublicId(Guid publicId)
    {
        this.publicId = publicId;
        return this;
    }

    public OrderFactory SetShippingStatus(ShippingStatus shippingStatus)
    {
        this.shippingStatus = shippingStatus;
        return this;
    }

    public OrderFactory SetPaymentStatus(PaymentStatus paymentStatus)
    {
        this.paymentStatus = paymentStatus;
        return this;
    }

    public OrderFactory SetTotalPrice(ICollection<Product> shoppingCardsItems)
    {
        double totalPrice = 0;
        foreach (var item in shoppingCardsItems)
        {
            totalPrice += item.Price;
        }
        this.totalPrice = totalPrice;
        return this;
    }

    public OrderFactory SetShoppingCardsItems(ICollection<Product> shoppingCardsItems)
    {
        this.shoppingCardsItems = shoppingCardsItems;
        return this;
    }

    public OrderFactory SetOrderPlaced()
    {
        this.orderPlaced = DateTime.Now;
        return this;
    }

    public OrderFactory SetAdress(Adress adress)
    {
        this.adress = adress;
        return this;
    }

    public OrderFactory SetContact(Contact contact)
    {
        this.contact = contact;
        return this;
    }

    public OrderFactory SetPersonalInfo(PersonalInfo personalInfo)
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
                ShoppingCardsItems: shoppingCardsItems,
                OrderPlaced: orderPlaced,
                DeliveryAddress: adress,
                CustomerContact: contact,
                CustomerInfo: personalInfo
            );
        return order;
    }
}
