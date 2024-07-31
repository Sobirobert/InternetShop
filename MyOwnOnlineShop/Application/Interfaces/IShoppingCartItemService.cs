using Application.Dto;
using Application.Dto.ShoppingcartItemDto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IShoppingCartItemService
    {
        Task<IEnumerable<ShoppingCartItemDto>> GetAllShoppingCartItems(int shoppingCartId);
        Task<IEnumerable<ProductDto>> GetAllProducts(int shoppingCartId);
        Task<ShoppingCartItemDto> GetShoppingCartItemById(int id);
        Task<CreateShoppingCartItemDto> AddNewShoppingCartItem(int idProduct);
        Task UpdateShioppingCartItem(ShoppingCartItemDto shoppingCartItem);
        Task DeleteShioppingCartItem(int shoppingCartItemId);
        Task ClearAllShioppingCartItems(ShoppingCartDto shoppingCart);
    }
}
