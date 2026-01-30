using Microsoft.AspNetCore.Mvc;

namespace ResumeProjectNight.ViewComponents.DefaultViewComponents
{
    public class _DefaultPreLoaderCompenentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
