using Microsoft.AspNetCore.Mvc;
using GutCheck.Web.Models;
using Microsoft.AspNetCore.Authorization;
using GutCheck.Core.Entities;

namespace GutCheck.Web.Controllers
{
    [Authorize]
    public class TrackingController : BaseController
    {
        [HttpGet]
        public IActionResult Food()
        {
            return View(new BaseViewModel { Subtitle = "Food" });
        }

        [HttpGet]
        public IActionResult Weight()
        {
            return View(ViewModelFactory.CreateWeightViewModel());
        }

        [HttpGet]
        public IActionResult Progress()
        {
            return View(new BaseViewModel { Subtitle = "Progress" });
        }

        [HttpPost]
        public IActionResult SaveWeight(WeightViewModel weightModel)
        {
            Console.WriteLine(weightModel.Data);
            return View("Weight", ViewModelFactory.CreateWeightViewModel());
        }
    }
}
