using Microsoft.AspNetCore.Mvc;

namespace DemansAppWeb.Controllers
{
    public class CommandsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
