using Microsoft.AspNetCore.Mvc;

namespace BookWeb.WebUI.Management.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
