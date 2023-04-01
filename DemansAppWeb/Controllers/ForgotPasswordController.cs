using Microsoft.AspNetCore.Mvc;

namespace DemansAppWeb.Controllers
{
    public class ForgotPasswordController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
