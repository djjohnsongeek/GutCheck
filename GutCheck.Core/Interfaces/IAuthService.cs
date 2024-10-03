using GutCheck.Core.Entities;

namespace GutCheck.Core.Interfaces
{
	public interface IAuthService
	{
		Task<User?> AuthenticateUser(string username, string password);
	}
}
