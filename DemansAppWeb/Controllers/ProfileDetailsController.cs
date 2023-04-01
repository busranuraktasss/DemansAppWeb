using Microsoft.AspNetCore.Mvc;

namespace DemansAppWeb.Controllers
{
    public class ProfileDetailsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
