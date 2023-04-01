using Microsoft.AspNetCore.Mvc;

namespace DemansAppWeb.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
