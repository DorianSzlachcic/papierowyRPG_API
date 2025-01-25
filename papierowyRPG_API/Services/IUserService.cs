using papierowyRPG_API.Forms;
using papierowyRPG_API.Models;

namespace papierowyRPG_API.Services;

public interface IUserService
{
    public List<User> GetUsers();
    public User? GetUser(int userId);
    public User? AuthenticateUser(LoginForm loginForm);
    public User? RegisterUser(RegisterForm registerForm);
    public bool? DeleteUser(int userId);
}