using System.Security.Cryptography;
using System.Text;
using GutCheck.Core.Entities;
using GutCheck.Core.Interfaces;
using GutCheck.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;

namespace GutCheck.Infrastructure.Services
{
	public class AuthService : IAuthService
	{
		private UserRepository UserRepo { get; set; }

		public AuthService(IConfiguration config, UserRepository userRepo)
		{
			UserRepo = userRepo;
		}

		public async Task<User?> AuthenticateUser(string username, string password)
		{
			User? user = await UserRepo.GetUserByUsername(username);
			if (user != null)
			{
				string pwHash = HashPassword(password);
				if (pwHash == user.HashedPassword)
				{
					return user;
				}
			}

			return null;
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
