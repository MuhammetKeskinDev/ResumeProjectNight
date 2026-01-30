using Microsoft.AspNetCore.Mvc;

namespace ResumeProjectNight.ViewComponents.DefaultViewComponents
{
    public class _DefaultHomeComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
