using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using papierowyRPG_API.Services;

namespace papierowyRPG_API.IntegrationTests;

public class TestsWebApplicationFactory : WebApplicationFactory<Program>
{
    public Mock<IUserService> UserServiceMock { get; } = new();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);

        builder.ConfigureTestServices(services =>
        {
            services.AddSingleton(UserServiceMock.Object);
        });
    }
}