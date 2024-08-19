using Application.Dto;
using Application.Dto.ShoppingcardItemDto;
using Application.Dto.ShoppingcartItemDto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IShoppingCardItemService
    {
        Task<IEnumerable<ShoppingCardItemDto>> GetAllShoppingCardItems(int shoppingCartId);
        Task<IEnumerable<ProductDto>> GetAllProducts(int shoppingCartId);
        Task<ShoppingCardItemDto> GetShoppingCardItemById(int id);
        Task<CreateShoppingCardItemDto> AddNewShoppingCardItem(int idProduct, int shoppingCardId);
        Task UpdateShoppingCardItem(UpdateShoppingCardItemDto shoppingCardItem);
        Task DeleteShioppingCardItem(int shoppingCardItemId);
        Task ClearAllShioppingCardItems(int shoppingCardId);
    }
}
