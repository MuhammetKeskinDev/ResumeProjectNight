using Microsoft.AspNetCore.Mvc;

namespace ResumeProjectNight.Controllers
{
    public class AdminlayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
