using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GutCheck.Web.Controllers
{
    public class BaseController : Controller
    {
        public int CurrentUserId
        {
            get
            {
                string nameIdentifier = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value;
                return int.TryParse(nameIdentifier, out int userId) ? userId : 0;
            }
        }
    }
}
