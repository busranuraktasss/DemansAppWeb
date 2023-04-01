using Microsoft.AspNetCore.Mvc;

namespace DemansAppWeb.Controllers
{
    public class AudioBooksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
