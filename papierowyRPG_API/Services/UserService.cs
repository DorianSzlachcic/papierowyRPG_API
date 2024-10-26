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
    }
}
