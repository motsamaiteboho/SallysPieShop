using Microsoft.AspNetCore.Mvc;
using Sally_sPieShop.Models;

namespace Sally_sPieShop.Controllers
{

    public class FeedbackController : Controller
    {
        private readonly IFeedbackRepository _feedbackRepository;
        public FeedbackController(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                _feedbackRepository.AddFeedback(feedback);
                return RedirectToAction("FeedbackComplete");
            }
            else
                return View(feedback);
        }

        public IActionResult FeedbackComplete()
        {
            return View();
        }

    }
}