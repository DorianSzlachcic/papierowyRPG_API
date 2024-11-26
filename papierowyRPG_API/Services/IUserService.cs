using papierowyRPG_API.Models;

namespace papierowyRPG_API.Services;

public interface IUserService
{
    public List<User> GetUsers();
    public User? AuthenticateUser(string username, string password);
    public User? RegisterUser(User user);
}