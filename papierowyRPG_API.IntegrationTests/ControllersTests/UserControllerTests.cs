using System.Net.Http.Json;
using Newtonsoft.Json;
using papierowyRPG_API.Controllers;
using papierowyRPG_API.Models;

namespace papierowyRPG_API.IntegrationTests.ControllersTests;

public class UserControllerTests
{
    private TestsWebApplicationFactory factory;
    private HttpClient client;

    public UserControllerTests()
    {
        this.factory = new TestsWebApplicationFactory();
        this.client = factory.CreateClient();
    }

    [Fact]
    public async Task GetAllAsync_ReturnsAllUsers()
    {
        var mockUsers = new List<User>
        {
            new User {ID = 1, Username = "admin", Password = "qwerty", Email = "admin@admin.com" },
            new User {ID = 2, Username = "user", Password = "123456", Email = "user@user.com" },
        };
        
        factory.UserServiceMock.Setup(r => r.GetUsers()).Returns(mockUsers);
        
        var response = await client.GetAsync("/api/users");
        response.EnsureSuccessStatusCode();
        
        var data = JsonConvert.DeserializeObject<IEnumerable<User>>(await response.Content.ReadAsStringAsync());
        Assert.Collection(data!, 
            user =>
            {
                Assert.Equal(1, user.ID);
                Assert.Equal("admin", user.Username);
                Assert.Equal("qwerty", user.Password);
                Assert.Equal("admin@admin.com", user.Email);
            },
            user =>
            {
                Assert.Equal(2, user.ID);
                Assert.Equal("user", user.Username);
                Assert.Equal("123456", user.Password);
                Assert.Equal("user@user.com", user.Email);
            });
    }

    [Fact]
    public async Task RegisterAsync_ReturnsCreatedUser()
    {
        var registerForm = new RegisterForm { Username = "johndoe", Password = "abcdefg", Email = "john@doe.com" };
        var user = new User(registerForm);
        
        factory.UserServiceMock.Setup(r => r.RegisterUser()).Returns(mockUsers);
        
        var response = await client.PostAsync(
            "/api/users/register",
            JsonContent.Create(new RegisterForm
            {
                Username = "johndoe",
                Password = "abcdefg",
                Email = "john@doe.com"
            }));
        response.EnsureSuccessStatusCode();
        
        var data = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
        Assert.NotNull(data);
        
        Assert.Equal(data.Email, data.Email);
    }
}