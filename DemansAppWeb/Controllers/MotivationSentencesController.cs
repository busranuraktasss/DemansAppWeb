using Microsoft.AspNetCore.Mvc;

namespace DemansAppWeb.Controllers
{
    public class MotivationSentencesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
