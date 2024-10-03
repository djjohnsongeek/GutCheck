using GutCheck.Infrastructure.Data;

namespace GutCheck.Infrastructure.Repositories
{
	public class Repository
	{
		protected DapperContext DbContext;

		public Repository(DapperContext dapperContext)
		{
			DbContext = dapperContext;
		}
	}
}
