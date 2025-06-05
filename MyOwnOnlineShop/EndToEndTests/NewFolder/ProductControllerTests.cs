using Application.Dto.ProductDtoFolder;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net;
using System.Reflection;
using WebAPI;
using WebAPI.Wrappers;

namespace EndToEndTests.NewFolder;

public class ProductControllerTests
{
    private readonly HttpClient _client;
    private readonly TestServer _server;
    public ProductControllerTests()
    {
        // Arrange

        var projectDir = Helper.GetProjectPath("", typeof(Program).GetTypeInfo().Assembly);
        _server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseContentRoot(projectDir)
                .UseConfiguration(new ConfigurationBuilder()
                    .SetBasePath(projectDir)
                    .AddJsonFile("appsettings.json")
                .Build()
            )
            .UseStartup<Program>());
        _client = _server.CreateClient();
    }

    [Fact]
    public async Task FetchingProductsShouldReturnNotEmptyCollection()
    {
        // Act
        var response = await _client.GetAsync(@"api/Products");
        var content = await response.Content.ReadAsStringAsync();
        var pagedResponse = JsonConvert.DeserializeObject<PagedResponse<IEnumerable<ProductDto>>>(content);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        pagedResponse?.Data.Should().NotBeEmpty();
    }

    [Fact]
    public async Task FetchingRequestPostIdShouldReturnOnlyOneResult()
    {
        // Acts
        var response = await _client.GetAsync(@"api/Posts/1");
        var content = await response.Content.ReadAsStringAsync();
        var post = JsonConvert.DeserializeObject<Response<ProductDto>>(content);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        post?.Data.Should().NotBeNull();
        // should return just one post with Id 1
        post?.Data?.Id.Should().Be(1);
    }
}
