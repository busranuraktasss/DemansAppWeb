using Microsoft.AspNetCore.Mvc;

namespace DemansAppWeb.Controllers
{
    public class TracesOfLoveController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
