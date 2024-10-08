using GutCheck.Core.Types;

namespace GutCheck.Core.Interfaces
{
	public interface IAuthService
	{
        Task<AuthResult> AuthenticateUser(string username, string password);
	}
}
