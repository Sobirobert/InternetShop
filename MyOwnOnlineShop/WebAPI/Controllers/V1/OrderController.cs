using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using System.Text;
using Domain.Entities;
using AutoMapper;

namespace WebAPI.Controllers.V1;

[Authorize]
public class OrderController : Controller
{
    private readonly IOrderRepository _orderRepository;
    private readonly IShoppingCartRepository _shoppingCartRepository;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;


    public OrderController(IOrderRepository orderRepository, IShoppingCartRepository shoppingCartRepository, IConfiguration configuration, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _shoppingCartRepository = shoppingCartRepository;
        _configuration = configuration;
        _mapper = mapper;
    }

    //// GET: /<controller>/
    //public IActionResult Checkout()
    //{
    //    return View();
    //}

    //[HttpPost]
    //public IActionResult Checkout(Order order)
    //{
    //    var items = _shoppingCartRepository.GetShoppingCartItemsAsync();

    //    if (items == null)
    //    {
    //        ModelState.AddModelError("", "Twój koszyk jest pusty. Dodaj pierwszy produkt");
    //    }

    //    if (ModelState.IsValid)
    //    {
    //        _orderRepository.CreateOrder(order);
    //        SendEmail(order);
    //        _shoppingCartRepository.ClearCartAsync();
    //        return RedirectToAction("CheckoutComplete");
    //    }
    //    return View(order);
    //}

    //private void SendEmail(Order order)
    //{
    //    if (string.IsNullOrWhiteSpace(_configuration.GetSection("Emails").GetValue<string>("UserName"))
    //    || string.IsNullOrWhiteSpace(_configuration.GetSection("Emails").GetValue<string>("Password"))
    //    || string.IsNullOrWhiteSpace(_configuration.GetSection("Emails").GetValue<string>("FromEmail")))
    //    {
    //        return;
    //    }

    //    var smtpClient = new SmtpClient(_configuration.GetSection("Emails").GetValue<string>("SmtpServer"))
    //    {
    //        Port = _configuration.GetSection("Emails").GetValue<int>("Port"),
    //        Credentials = new NetworkCredential(
    //            _configuration.GetSection("Emails").GetValue<string>("UserName"),
    //            _configuration.GetSection("Emails").GetValue<string>("Password")),
    //        EnableSsl = _configuration.GetSection("Emails").GetValue<bool>("EnableSsl"),
    //    };

    //    smtpClient.Send(
    //        _configuration.GetSection("Emails").GetValue<string>("FromEmail"),
    //        _configuration.GetSection("Emails").GetValue<string>("FromEmail"),
    //        $"Nowe Zamówienie nr #{order.OrderId}",
    //        CreateEmailBody(order));
    //}

    //private static string CreateEmailBody(Order order)
    //{
    //    var stringBuilder = new StringBuilder($"Nowe Zamówienie nr #{order.OrderId}{Environment.NewLine + Environment.NewLine}");
    //    foreach (var orderDetail in order.OrderDetails)
    //    {
    //        stringBuilder.Append($"-> {orderDetail.Product.Title}: {orderDetail.Amount}x{orderDetail.Product.Price:#.##}{Environment.NewLine}");
    //    }

    //    stringBuilder.Append(Environment.NewLine);
    //    stringBuilder.Append($"SUMA: {order.OrderTotal:#.##}");
    //    stringBuilder.Append(Environment.NewLine);
    //    stringBuilder.Append(Environment.NewLine);
    //    stringBuilder.Append($"Zamawiający:");
    //    stringBuilder.Append(Environment.NewLine);
    //    stringBuilder.Append($"{order.FirstName} {order.LastName}");
    //    stringBuilder.Append(Environment.NewLine);
    //    stringBuilder.Append(order.Email);
    //    stringBuilder.Append(Environment.NewLine);
    //    stringBuilder.Append(order.PhoneNumber);
    //    stringBuilder.Append(Environment.NewLine);
    //    stringBuilder.Append(order.AddressLine1);
    //    stringBuilder.Append(Environment.NewLine);
    //    stringBuilder.Append(order.AddressLine2);
    //    stringBuilder.Append(Environment.NewLine);
    //    stringBuilder.Append($"{order.ZipCode} {order.City}");
    //    stringBuilder.Append(Environment.NewLine);
    //    stringBuilder.Append(order.Country);
    //    stringBuilder.Append(Environment.NewLine);
    //    stringBuilder.Append(order.State);

    //    stringBuilder.Append(Environment.NewLine);
    //    stringBuilder.Append(Environment.NewLine);
    //    return stringBuilder.ToString();
    //}

    //public IActionResult CheckoutComplete()
    //{
    //    ViewBag.CheckoutCompleteMessage = "Dziękujemy za zamówienie";
    //    return View();
    //}
}
