using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using GutCheck.Core.Entities;
using Microsoft.Extensions.Configuration;

namespace GutCheck.Infrastructure.Services
{
    public class AuthService
    {
        public AuthService(IConfiguration config)
        {

        }

        public User AuthenticateUser(string username, string password)
        {
            return new User
            {
                Username = username,
                Email = "",
                HashedPassword = "",
                Role = "Subscriber"
            };
        }

        private string HashPassword(string input)
        {
            using var sha = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
