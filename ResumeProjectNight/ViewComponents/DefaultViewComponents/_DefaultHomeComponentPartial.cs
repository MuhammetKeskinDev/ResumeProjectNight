using Microsoft.AspNetCore.Mvc;
using ResumeProjectNight.Context;
using ResumeProjectNight.Models;

namespace ResumeProjectNight.ViewComponents.DefaultViewComponents
{
    public class _DefaultHomeComponentPartial : ViewComponent
    {
        private readonly ResumeContext _context;

        public _DefaultHomeComponentPartial(ResumeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var homeHero = _context.HomeHeroes.FirstOrDefault();
            var socialMedias = _context.SocialMedias
                .Where(x => x.IsActive)
                .OrderBy(x => x.SortOrder)
                .ToList();

            var model = new HomeHeroViewModel
            {
                HomeHero = homeHero,
                SocialMedias = socialMedias
            };

            return View(model);
        }
    }
}
