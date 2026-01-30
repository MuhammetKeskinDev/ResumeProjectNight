using Microsoft.AspNetCore.Mvc;

namespace ResumeProjectNight.ViewComponents.DefaultViewComponents
{
    public class _DefaultScriptsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }    
}
