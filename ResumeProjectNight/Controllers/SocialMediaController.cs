using Microsoft.AspNetCore.Mvc;
using ResumeProjectNight.Context;
using ResumeProjectNight.Entities;

namespace ResumeProjectNight.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly ResumeContext _context;

        public SocialMediaController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.SocialMedias.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia socialMedia)
        {
            _context.SocialMedias.Add(socialMedia);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {
            var value = _context.SocialMedias.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            var value = _context.SocialMedias.Find(socialMedia.SocialMediaId);
            value.IconClass = socialMedia.IconClass;
            value.Url = socialMedia.Url;
            value.IsActive = socialMedia.IsActive;
            value.SortOrder = socialMedia.SortOrder;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _context.SocialMedias.Find(id);
            _context.SocialMedias.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

