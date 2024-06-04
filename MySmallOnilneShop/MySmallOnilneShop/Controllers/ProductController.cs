using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MySmallOnilneShop.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


    }
}
