using papierowyRPG_API.Models;

namespace papierowyRPG_API.Forms;
public class LoginForm
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}

public class RegisterForm : LoginForm
{
    public required string Email { get; set; }

    public User ToUser()
    {
        return new User
        {
            Username = Username,
            Password = Password,
            Email = Email
        };
    }

    public User ToUser(int id)
    {
        return new User
        {
            ID = id,
            Username = Username,
            Password = Password,
            Email = Email
        };
    }
}
