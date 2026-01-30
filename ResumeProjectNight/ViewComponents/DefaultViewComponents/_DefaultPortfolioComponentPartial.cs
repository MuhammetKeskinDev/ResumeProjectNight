using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResumeProjectNight.Context;

namespace ResumeProjectNight.ViewComponents.DefaultViewComponents
{
    public class _DefaultPortfolioComponentPartial : ViewComponent
    {
        private readonly ResumeContext _context;

        public _DefaultPortfolioComponentPartial(ResumeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Portfolios
                .Include(p => p.ProjectCategory)
                .ToList();
            return View(values);
        }
    }
}
