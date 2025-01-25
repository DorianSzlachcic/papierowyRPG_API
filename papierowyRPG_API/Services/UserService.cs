using Microsoft.EntityFrameworkCore;
using papierowyRPG_API.Database;
using papierowyRPG_API.Forms;
using papierowyRPG_API.Models;

namespace papierowyRPG_API.Services
{
    public class UserService(UserContext userContext) : IUserService, IDisposable
    {
        public List<User> GetUsers()
        {
            return userContext.Users.ToList();
        }

        public User? GetUser(int userId)
        {
            try
            {
                return userContext.Users.First(x => x.ID == userId);
            }
            catch (InvalidOperationException)  // User is not found
            {
                return null;
            }
        }

        public User? GetUser(string username)
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

        public User? AuthenticateUser(LoginForm loginForm)
        {
            var user = GetUser(loginForm.Username);
            if (user == null)
                return null;
            if (user.Password != loginForm.Password)
                return null;
            return user;
        }

        public User? RegisterUser(RegisterForm registerForm)
        {
            var user = registerForm.ToUser();
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

        public bool? DeleteUser(int userId)
        {
            var user = GetUser(userId);
            if (user == null) return null;
            userContext.Users.Remove(user);
            try { userContext.SaveChanges(); } catch { return null; }
            return true;
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
