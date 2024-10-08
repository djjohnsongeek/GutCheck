using GutCheck.Core.Entities;

namespace GutCheck.Core.Interfaces
{
	public interface IUserRepository
	{
		Task<User?> GetUserByUsername(string username);

		Task<User?> GetUserById(int id);
	}
}
