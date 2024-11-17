using papierowyRPG_API.Database;
using papierowyRPG_API.Models;

namespace papierowyRPG_API.Services
{
    public class UserService
    {
        private UserContext userContext;

        public UserService()
        {
            userContext = new UserContext();
        }

        public List<User> GetUsers()
        {
            return userContext.Users.ToList();
        }

        private User? GetUser(string username)
        {
            try
            {
                return userContext.Users.First(x => x.Username == username);
            }
            catch (InvalidOperationException)  // User is not found
            {
                return null;
            }
        }

        public User? AuthenticateUser(string username, string password)
        {
            var user = GetUser(username);
            if (user == null)
                return null;
            if (user.Password != password)
                return null;
            return user;
        }
    }
}
