using Microsoft.AspNetCore.Mvc;
using GutCheck.Web.Models;

namespace GutCheck.Web.Controllers
{
    public class TrackingController : BaseController
    {
        public IActionResult Food()
        {
            return View(new BaseViewModel { Subtitle = "Food" });
        }

        public IActionResult Weight()
        {
            return View(new BaseViewModel { Subtitle = "Weight" });
        }

        public IActionResult Progress()
        {
            return View(new BaseViewModel { Subtitle = "Progress" });
        }
    }
}
