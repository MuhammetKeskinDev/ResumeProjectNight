using Microsoft.AspNetCore.Mvc;
using ResumeProjectNight.Context;

namespace ResumeProjectNight.ViewComponents.DefaultViewComponents
{
    public class _DefaultTestimonialComponentPartial : ViewComponent
    {
      private readonly ResumeContext _context;

        public _DefaultTestimonialComponentPartial(ResumeContext context)
        {
            _context=context;
        }

        public IViewComponentResult Invoke()
        {
           var test = _context.Testimonials.ToList();
            return View(test);
        }
    }
}
