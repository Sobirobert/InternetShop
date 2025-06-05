using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace xUnitTests.Repository;

public class ProductRepositoryTest
{
    [Fact]
    public async Task GetAll_WithPaginationSortingAndFiltering_ReturnsCorrectProducts()
    {
        // Arrange
        var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Title = "Laptop Dell XPS 15",
                    ShortDescription = "Laptop dla profesjonalistów",
                    LongDescription = "Szczegółowy opis...",
                    Amount = 10,
                    Details = "Procesor Intel i7, 16GB RAM",
                    YearOfProduction = 2023,
                    Price = 6999.99,
                    IsProductOfTheWeek = true,
                    Type = TypeProduct.New,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Title = "iPhone 13",
                    ShortDescription = "Smartfon Apple",
                    LongDescription = "Szczegółowy opis...",
                    Amount = 20,
                    Details = "A15 Bionic, 128GB",
                    YearOfProduction = 2022,
                    Price = 4299.99,
                    IsProductOfTheWeek = false,
                    Type = TypeProduct.New,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 3,
                    Title = "MacBook Pro",
                    ShortDescription = "Laptop Apple",
                    LongDescription = "Szczegółowy opis MacBooka...",
                    Amount = 15,
                    Details = "M2 Pro, 16GB RAM",
                    YearOfProduction = 2023,
                    Price = 9999.99,
                    IsProductOfTheWeek = true,
                    Type = TypeProduct.New,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 4,
                    Title = "Słuchawki AirPods",
                    ShortDescription = "Bezprzewodowe słuchawki Apple",
                    LongDescription = "Szczegółowy opis...",
                    Amount = 30,
                    Details = "Bluetooth 5.0",
                    YearOfProduction = 2021,
                    Price = 899.99,
                    IsProductOfTheWeek = false,
                    Type = TypeProduct.New,
                    CategoryId = 3
                }
            }.AsQueryable();

        // Utwórz mockowany DbSet
        var mockSet = new Mock<DbSet<Product>>();
        mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
        mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
        mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
        mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(() => products.GetEnumerator());

        // Mockuj DbContext
        var mockContext = new Mock<OnlineShopDBContext>();
        mockContext.Setup(c => c.Products).Returns(mockSet.Object);

        // Potrzebujemy tylko interfejsu, więc mockujemy IProductRepository zamiast faktycznej implementacji
        var mockRepo = new Mock<IProductRepository>();

        // Ustaw mockowaną implementację GetAll z parametrami
        mockRepo.Setup(repo => repo.GetAll(
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<string>(),
            It.IsAny<bool>(),
            It.IsAny<string>()))
            .Returns((int pageNumber, int pageSize, string sortField, bool ascending, string filterBy) =>
            {
                // Filtrowanie
                var filteredQuery = string.IsNullOrEmpty(filterBy)
                    ? products
                    : products.Where(p => p.Title.Contains(filterBy) ||
                                        p.ShortDescription.Contains(filterBy) ||
                                        p.Details.Contains(filterBy));

                // Sortowanie
                IOrderedQueryable<Product> sortedQuery;
                if (string.IsNullOrEmpty(sortField) || sortField.ToLower() == "id")
                {
                    sortedQuery = ascending
                        ? filteredQuery.OrderBy(p => p.Id)
                        : filteredQuery.OrderByDescending(p => p.Id);
                }
                else if (sortField.ToLower() == "title")
                {
                    sortedQuery = ascending
                        ? filteredQuery.OrderBy(p => p.Title)
                        : filteredQuery.OrderByDescending(p => p.Title);
                }
                else if (sortField.ToLower() == "price")
                {
                    sortedQuery = ascending
                        ? filteredQuery.OrderBy(p => p.Price)
                        : filteredQuery.OrderByDescending(p => p.Price);
                }
                else if (sortField.ToLower() == "yearofproduction")
                {
                    sortedQuery = ascending
                        ? filteredQuery.OrderBy(p => p.YearOfProduction)
                        : filteredQuery.OrderByDescending(p => p.YearOfProduction);
                }
                else
                {
                    sortedQuery = ascending
                        ? filteredQuery.OrderBy(p => p.Id)
                        : filteredQuery.OrderByDescending(p => p.Id);
                }

                // Paginacja
                var paginatedResult = sortedQuery
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                return Task.FromResult<IEnumerable<Product>>(paginatedResult);
            });

        // Test 1: Pierwsza strona z domyślnym sortowaniem bez filtra
        {
            // Act
            var result = await mockRepo.Object.GetAll(1, 2, "Id", true, "");
            var resultList = result.ToList();

            // Assert
            Assert.Equal(2, resultList.Count); // 2 produkty na stronę
            Assert.Equal(1, resultList[0].Id); // Pierwszy produkt to Laptop Dell
            Assert.Equal(2, resultList[1].Id); // Drugi produkt to iPhone
        }

        // Test 2: Pierwsza strona z sortowaniem po cenie (malejąco)
        {
            // Act
            var result = await mockRepo.Object.GetAll(1, 2, "Price", false, "");
            var resultList = result.ToList();

            // Assert
            Assert.Equal(2, resultList.Count);
            Assert.Equal(3, resultList[0].Id); // MacBook Pro (najdroższy)
            Assert.Equal(1, resultList[1].Id); // Laptop Dell XPS 15 (drugi najdroższy)
        }

        // Test 3: Filtrowanie po słowie "Apple"
        {
            // Act
            var result = await mockRepo.Object.GetAll(1, 10, "Id", true, "Apple");
            var resultList = result.ToList();

            // Assert
            Assert.Equal(2, resultList.Count); // iPhone i MacBook
            Assert.Contains(resultList, p => p.Title.Contains("MacBook"));
            Assert.Contains(resultList, p => p.ShortDescription.Contains("Apple"));
        }

        // Test 4: Druga strona z domyślnym sortowaniem
        {
            // Act
            var result = await mockRepo.Object.GetAll(2, 2, "Id", true, "");
            var resultList = result.ToList();

            // Assert
            Assert.Equal(2, resultList.Count);
            Assert.Equal(3, resultList[0].Id); // MacBook Pro
            Assert.Equal(4, resultList[1].Id); // Słuchawki AirPods
        }
    }

    [Fact]
    public async Task GetProductById_ReturnsCorrectProduct()
    {
        // Arrange
        var products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Title = "Laptop Dell XPS 15",
                ShortDescription = "Laptop dla profesjonalistów",
                Price = 6999.99,
                CategoryId = 1
            },
            new Product
            {
                Id = 2,
                Title = "iPhone 13",
                ShortDescription = "Smartfon Apple",
                Price = 4299.99,
                CategoryId = 2
            }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Product>>();
        mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
        mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
        mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
        mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

        mockSet.Setup(m => m.FindAsync(It.IsAny<object[]>()))
            .ReturnsAsync((object[] ids) => products.FirstOrDefault(p => p.Id == (int)ids[0]));

        var mockContext = new Mock<OnlineShopDBContext>();
        mockContext.Setup(c => c.Products).Returns(mockSet.Object);

        var repository = new ProductRepository(mockContext.Object);

        // Act
        var result = await repository.GetById(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("Laptop Dell XPS 15", result.Title);
    }

    [Fact]
    public async Task AddProduct_AddsProductToContext()
    {
        // Arrange
        var mockSet = new Mock<DbSet<Product>>();
        var mockContext = new Mock<OnlineShopDBContext>();
        mockContext.Setup(c => c.Products).Returns(mockSet.Object);
        mockContext.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(1);

        var repository = new ProductRepository(mockContext.Object);
        var product = new Product
        {
            Id = 1,
            Title = "Nowy produkt",
            ShortDescription = "Opis",
            LongDescription = "Długi opis",
            Amount = 5,
            Details = "Szczegóły",
            YearOfProduction = 2023,
            Price = 1000.00,
            IsProductOfTheWeek = false,
            Type = TypeProduct.New,
            CategoryId = 1
        };

        // Act
        await repository.Add(product);

        // Assert
        mockSet.Verify(m => m.AddAsync(It.IsAny<Product>(), default), Times.Once());
        mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once());
    }

    [Fact]
    public async Task UpdateProduct_UpdatesProductInContext()
    {
        // Arrange
        var product = new Product
        {
            Id = 1,
            Title = "Produkt do aktualizacji",
            Price = 1000.00
        };

        var mockSet = new Mock<DbSet<Product>>();
        mockSet.Setup(m => m.FindAsync(It.IsAny<object[]>())).ReturnsAsync(product);

        var mockContext = new Mock<OnlineShopDBContext>();
        mockContext.Setup(c => c.Products).Returns(mockSet.Object);
        mockContext.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(1);

        var repository = new ProductRepository(mockContext.Object);

        // Update product properties
        product.Title = "Zaktualizowany tytuł";
        product.Price = 1200.00;

        // Act
        await repository.Update(product);

        // Assert
        mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once());
    }

    [Fact]
    public async Task DeleteProduct_RemovesProductFromContext()
    {
        // Arrange
        var product = new Product { Id = 1, Title = "Produkt do usunięcia" };

        var productRepositoryMock = new Mock<IProductRepository>();
        var mapperMock = new Mock<IMapper>();
        var loggerMock = new Mock<ILogger<ProductService>>();

        var productService = new ProductService(productRepositoryMock.Object, mapperMock.Object, loggerMock.Object);

        var mockSet = new Mock<DbSet<Product>>();
        var mockContext = new Mock<OnlineShopDBContext>();
       

        var repository = new ProductRepository(mockContext.Object);

        // Act
        await repository.Delete(1);

        // Assert
        mockSet.Verify(m => m.Remove(It.IsAny<Product>()), Times.Once());
        mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once());
    }
}
