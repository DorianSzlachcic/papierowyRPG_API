using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using papierowyRPG_API.Database;
using papierowyRPG_API.Models;

namespace papierowyRPG_API.Services
{
    public class UserService(UserContext userContext) : IUserService, IDisposable
    {
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

        public User? RegisterUser(User user)
        {
            userContext.Users.Add(user);
            try
            {
                userContext.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return null;
            }
            return user;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                userContext.Dispose();
            }
        }
    }
}
