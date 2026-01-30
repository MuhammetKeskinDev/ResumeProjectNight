using Microsoft.AspNetCore.Mvc;
using ResumeProjectNight.Context;

namespace ResumeProjectNight.ViewComponents.DefaultViewComponents
{
    public class _DefaultCategoryCompenentPartial : ViewComponent
    {
        private readonly ResumeContext _context;

        public _DefaultCategoryCompenentPartial(ResumeContext context)
        {
            _context=context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.ProjectCategories.ToList();
            return View(values);
        }
    }
}
