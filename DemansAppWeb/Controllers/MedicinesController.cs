using Microsoft.AspNetCore.Mvc;

namespace DemansAppWeb.Controllers
{
    public class MedicinesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
