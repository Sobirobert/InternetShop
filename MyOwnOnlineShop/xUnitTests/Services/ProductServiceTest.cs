using Application.Dto;
using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Xunit;
using Xunit.Sdk;

namespace xUnitTests.Services;

public class ProductServiceTest
{
    #region Add
    [Fact]
    public async Task AddProductShouldInvokeAddOnProductRepository()
    {
        //Arrange

        var productRepositoryMock = new Mock<IProductRepository>();
        var mapperMock = new Mock<IMapper>();
        var loggerMock = new Mock<ILogger<ProductService>>();

        var productService = new ProductService(productRepositoryMock.Object, mapperMock.Object, loggerMock.Object);

        var productDto = new CreateProductDto()
        {
            Title = "SomeTitile",
            ShortDescription = "Short text",
            LongDescription = "Long text",
            Details = "Some details",
            YearOfProduction = 2003,
            Amount = 1,
            Price = 23.23,
            IsProductOfTheWeek = false,
            Type = (TypeProduct)1,
            CategoryId = 1
        };

        mapperMock.Setup(x => x.Map<Product>(productDto)).Returns(new Product()
        {
            Title = productDto.Title,
            ShortDescription = productDto.ShortDescription,
            LongDescription = productDto.LongDescription,
            Details = productDto.Details,
            YearOfProduction = productDto.YearOfProduction,
            Amount = productDto.Amount,
            Price = productDto.Price,
            IsProductOfTheWeek = productDto.IsProductOfTheWeek,
            Type = productDto.Type,
            CategoryId = productDto.CategoryId,
        });

        //Act

        await productService.AddNewProduct(productDto);

        //Assert

        productRepositoryMock.Verify(x => x.Add(It.IsAny<Product>()), Times.Once);
        productDto.Should().NotBeNull();
        productDto.Title.Should().NotBeEmpty();
        productDto.ShortDescription.Should().NotBeNull();
        productDto.LongDescription.Should().NotBeNull();
        productDto.Details.Should().NotBeNull();
        productDto.YearOfProduction.Should().BePositive();
        productDto.YearOfProduction.Should().BeGreaterThan(2000);
        productDto.Amount.Should().BeGreaterThan(0);
        productDto.Price.Should().BePositive();
        productDto.Price.Should().BeGreaterThan(0);
        productDto.IsProductOfTheWeek.Should().BeFalse();
        productDto.Type.Should().BeOneOf((TypeProduct)1, (TypeProduct)2, (TypeProduct)3);
        productDto.CategoryId.Should().BeOneOf(1, 2, 3);
    }
    #endregion Add

    #region GetById
    [Fact]
    public async Task WhenInvokingGetProductByIdItShouldInvokeGetOnProductRepository()
    {
        //Arrange

        var productRepositoryMock = new Mock<IProductRepository>();
        var mapperMock = new Mock<IMapper>();
        var loggerMock = new Mock<ILogger<ProductService>>();

        var productService = new ProductService(productRepositoryMock.Object, mapperMock.Object, loggerMock.Object);

        var product = new Product()
        {
            Id = 1,
            Title = "SomeTitile",
            ShortDescription = "Short text",
            LongDescription = "Long text",
            Details = "Some details",
            YearOfProduction = 2003,
            Amount = 1,
            Price = 23.23,
            IsProductOfTheWeek = false,
            Type = (TypeProduct)1,
            CategoryId = 1
        };

        var productDto = new ProductDto()
        {
            Title = product.Title,
            ShortDescription = product.ShortDescription,
            LongDescription = product.LongDescription,
            Details = product.Details,
            YearOfProduction = product.YearOfProduction,
            Amount = product.Amount,
            Price = product.Price,
            IsProductOfTheWeek = product.IsProductOfTheWeek,
            Type = product.Type,
            CategoryId = product.CategoryId,
        };


        mapperMock.Setup(x => x.Map<Product>(productDto)).Returns(product);
        productRepositoryMock.Setup(x => x.GetById(product.Id)).ReturnsAsync(product);


        //Act

        var existingProduct = await productService.GetProductById(product.Id);

        //Assert

        productRepositoryMock.Verify(x => x.GetById(product.Id), Times.Once);
        productDto.Should().NotBeNull();
        productDto.ShortDescription.Should().NotBeNull();
        productDto.LongDescription.Should().NotBeNull();
        productDto.Details.Should().NotBeNull();
        productDto.YearOfProduction.Should().BePositive();
        productDto.Amount.Should().BeGreaterThan(0);
        productDto.Price.Should().BePositive();
        productDto.IsProductOfTheWeek.Should().BeFalse();
        productDto.Type.Should().BeOneOf((TypeProduct)1, (TypeProduct)2, (TypeProduct)3);
        productDto.CategoryId.Should().BeOneOf(1, 2, 3);

    }

    [Fact]
    public async Task GetProductByIdShouldThrowExceptionWhenProductDoesNotExist()
    {
        //Arrange

        var productRepositoryMock = new Mock<IProductRepository>();
        var mapperMock = new Mock<IMapper>();
        var loggerMock = new Mock<ILogger<ProductService>>();
        var productService = new ProductService(productRepositoryMock.Object, mapperMock.Object, loggerMock.Object);
        var wrongId = 22;

        productRepositoryMock
           .Setup(repo => repo.GetById(wrongId))
           .Throws<InvalidOperationException>()
           .
           .WithMessage("There are not product with this Id!");
        //Act

        Action act = () => productService.GetProductById(wrongId);

        //Assert

        act.Should().Throw<InvalidOperationException>()
            .WithInnerException<ArgumentException>()
            .WithMessage("There are not product with this Id!");
    }
    #endregion GetById

    #region Delete
    [Fact]
    public async Task DeleteProduct_WithExistingProductId_ShouldCallDeleteOnRepository()
    {
        //Arrange

        var productRepositoryMock = new Mock<IProductRepository>();
        var mapperMock = new Mock<IMapper>();
        var loggerMock = new Mock<ILogger<ProductService>>();

        var productService = new ProductService(productRepositoryMock.Object, mapperMock.Object, loggerMock.Object);
        var productId = 1;
        var product = new Product()
        {
            Id = 1,
            Title = "SomeTitile",
            ShortDescription = "Short text",
            LongDescription = "Long text",
            Details = "Some details",
            YearOfProduction = 2003,
            Amount = 1,
            Price = 23.23,
            IsProductOfTheWeek = false,
            Type = (TypeProduct)1,
            CategoryId = 1
        };

        productRepositoryMock.Setup(x => x.GetById(productId)).ReturnsAsync(product);
        //Act

        await productService.DeleteProduct(productId);

        //Assert
        productRepositoryMock.Verify(x => x.GetById(productId), Times.Once);
        productRepositoryMock.Verify(x => x.Delete(product.Id), Times.Once);
    }
    #endregion Delete
}
