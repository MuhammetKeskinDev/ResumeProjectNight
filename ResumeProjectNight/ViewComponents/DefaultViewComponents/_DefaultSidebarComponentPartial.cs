using Microsoft.AspNetCore.Mvc;

namespace ResumeProjectNight.ViewComponents.DefaultViewComponents
{
    public class _DefaultSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
