using System.Net;
using System.Net.Http.Json;
using Moq;
using Newtonsoft.Json;
using papierowyRPG_API.Controllers;
using papierowyRPG_API.Forms;
using papierowyRPG_API.Models;
using papierowyRPG_API.Services;

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
    public async Task LoginAsync_ReturnsUser()
    {
        var loginForm = new LoginForm() { Username = "johndoe", Password = "abcdefg" };
        var loggedUser = new User
        {
            ID = 1,
            Username = loginForm.Username,
            Password = loginForm.Password,
            Email = "abc@def.com",
        };

        factory.UserServiceMock
            .Setup(r => r.AuthenticateUser(It.IsAny<LoginForm>()))
            .Returns(loggedUser);

        var formData = new MultipartFormDataContent();
        formData.Add(new StringContent(loginForm.Username), "Username");
        formData.Add(new StringContent(loginForm.Password), "Password");

        var response = await client.PostAsync("/api/users/login", formData);
        response.EnsureSuccessStatusCode();
        var user = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());

        Assert.Equal(1, user!.ID);
        Assert.Equal("johndoe", user.Username);
        Assert.Equal("abcdefg", user.Password);
        Assert.Equal("abc@def.com", user.Email);
    }

    [Fact]
    public async Task LoginAsync_ReturnsUnauthorized()
    {
        var loginForm = new LoginForm() { Username = "johndoe", Password = "abcdefg" };

        factory.UserServiceMock
            .Setup(r => r.AuthenticateUser(It.IsAny<LoginForm>()))
            .Returns((User?)null);

        var formData = new MultipartFormDataContent();
        formData.Add(new StringContent(loginForm.Username), "Username");
        formData.Add(new StringContent(loginForm.Password), "Password");

        var response = await client.PostAsync("/api/users/login", formData);
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task RegisterAsync_ReturnsCreated()
    {
        var registerForm = new RegisterForm { Username = "johndoe", Password = "abcdefg", Email = "john@doe.com" };

        factory.UserServiceMock
            .Setup(r => r.RegisterUser(It.IsAny<RegisterForm>()))
            .Returns(registerForm.ToUser(1));

        var formData = new MultipartFormDataContent();
        formData.Add(new StringContent(registerForm.Username), "Username");
        formData.Add(new StringContent(registerForm.Password), "Password");
        formData.Add(new StringContent(registerForm.Email), "Email");

        var response = await client.PostAsync("/api/users/register", formData);
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        Assert.Equal("http://localhost/api/users/1", response.Headers.Location!.ToString());
    }

    [Fact]
    public async Task RegisterAsync_ReturnsUnprocessableEntity()
    {
        var registerForm = new RegisterForm { Username = "johndoe", Password = "abcdefg", Email = "john@doe.com" };

        factory.UserServiceMock
            .Setup(r => r.RegisterUser(It.IsAny<RegisterForm>()))
            .Returns((User?)null);

        var formData = new MultipartFormDataContent();
        formData.Add(new StringContent(registerForm.Username), "Username");
        formData.Add(new StringContent(registerForm.Password), "Password");
        formData.Add(new StringContent(registerForm.Email), "Email");

        var response = await client.PostAsync("/api/users/register", formData);
        Assert.Equal(HttpStatusCode.UnprocessableEntity, response.StatusCode);
    }
}