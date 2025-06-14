using Application.Dto.ProductDtoFolder;
using Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using WebAPI.Filters;
using WebAPI.Helpers;
using WebAPI.Wrappers;

namespace WebAPI.Functions.Queries.ProductQueries;

public class GetAllProductHandler(IProductService productService, IMemoryCache memoryCache, ILogger<GetAllProductHandler> logger)
    : IRequestHandler<GetAllProductQuery, PagedResponse<IEnumerable<ProductDto>>>
{
    public async Task<PagedResponse<IEnumerable<ProductDto>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        var validPaginationFilter = new PaginationFilter(request.PageNumber, request.PageSize);
        var validSortingFilter = new SortingFilter(request.SortField, request.Ascending);

        var cacheKey = $"products_{request.PageNumber}_{request.PageSize}_{request.SortField}_{request.Ascending}_{request.FilterBy}";
        var products = memoryCache.Get<IEnumerable<ProductDto>>(cacheKey);

        if (products == null)
        {
            logger.LogInformation("Fetching products from database");
            products = await productService.GetAllProducts(validPaginationFilter.PageNumber, validPaginationFilter.PageSize,
                                                                     validSortingFilter.SortField, validSortingFilter.Ascending, request.FilterBy);
            memoryCache.Set(cacheKey, products, TimeSpan.FromMinutes(1));
        }
        else
        {
            logger.LogInformation("Fetching products from cache");
        }

        var totalRecords = await productService.GetAllProductsCount(request.FilterBy);
        return PaginationHelper.CreatePageResponse(products, validPaginationFilter, totalRecords);
    }
}
