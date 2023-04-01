using Microsoft.AspNetCore.Mvc;

namespace DemansAppWeb.Controllers
{
    public class CommandController : Controller
    {
        private readonly ILogger<CommandController> _logger;

        public CommandController(ILogger<CommandController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
