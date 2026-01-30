using Microsoft.AspNetCore.Mvc;

namespace ResumeProjectNight.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
