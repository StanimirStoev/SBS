using Microsoft.AspNetCore.Mvc;

namespace SBS.Areas.Administration.Controllers
{
    /// <summary>
    /// Home Admin data
    /// </summary>
    public class HomeController : AdminController
    {
        /// <summary>
        /// Prepare data for main admin view
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
