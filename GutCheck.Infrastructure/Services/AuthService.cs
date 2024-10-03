using System.Security.Cryptography;
using System.Text;
using GutCheck.Core.Entities;
using GutCheck.Core.Interfaces;
using GutCheck.Core.Errors;
using Microsoft.Extensions.Configuration;
using System.Data.Common;
using GutCheck.Core.Types;

namespace GutCheck.Infrastructure.Services
{
	public class AuthService : IAuthService
	{
		private IUserRepository UserRepo { get; set; }

		public AuthService(IConfiguration config, IUserRepository userRepo)
		{
			UserRepo = userRepo;
		}

		public async Task<AuthResult> AuthenticateUser(string username, string password)
		{
			var result = new AuthResult();
			try
			{
				User? user = await UserRepo.GetUserByUsername(username);
				if (ValidatePassword(user, password))
				{
					result.User = user;
				}
				else
				{
					result.Errors.Add(new AuthenticationError("Invalid Login Credentials. Login Failed."));
				}
			}
			catch (DbException dbEx)
			{
				result.Errors.Add(new AuthenticationError("A Database error occured. Login Failed."));
				// TODO: Log the exception
			}

			return result;
		}

		private bool ValidatePassword(User? user, string password)
		{
			if (user == null)
			{
				return false;
			}

            string pwHash = HashPassword(password);
			return pwHash == user.HashedPassword;
        }

		public static string HashPassword(string input)
		{
			using var sha = SHA256.Create();
			byte[] bytes = Encoding.UTF8.GetBytes(input);
			byte[] hash = sha.ComputeHash(bytes);
			return Convert.ToBase64String(hash);
		}
	}
}
