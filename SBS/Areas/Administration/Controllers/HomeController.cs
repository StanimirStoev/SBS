using Microsoft.AspNetCore.Mvc;

namespace SBS.Areas.Administration.Controllers
{
    public class HomeController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
