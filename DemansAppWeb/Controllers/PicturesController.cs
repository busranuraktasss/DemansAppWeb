using Microsoft.AspNetCore.Mvc;

namespace DemansAppWeb.Controllers
{
    public class PicturesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
