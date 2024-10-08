using Microsoft.AspNetCore.Mvc;
using GutCheck.Web.Models;
using Microsoft.AspNetCore.Authorization;
using GutCheck.Core.Entities;
using GutCheck.Core.Interfaces;

namespace GutCheck.Web.Controllers
{
    [Authorize]
    public class TrackingController : BaseController
    {
        private ITrackingService TrackingService { get; set; }

        public TrackingController(ITrackingService trackingService)
        {
            TrackingService = trackingService;
        }

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
            TrackingService.TrackWeight(weightModel.ToDTO(CurrentUserId));

            List<ServerMessage> messages = new List<ServerMessage> { new ServerMessage("Weight Tracked!", ServerMessageCategory.Success) };
            return View("Weight", ViewModelFactory.CreateWeightViewModel(messages));
        }
    }
}
