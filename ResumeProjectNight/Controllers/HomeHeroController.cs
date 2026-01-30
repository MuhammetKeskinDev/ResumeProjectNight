using Microsoft.AspNetCore.Mvc;
using ResumeProjectNight.Context;
using ResumeProjectNight.Entities;

namespace ResumeProjectNight.Controllers
{
    public class HomeHeroController : Controller
    {
        private readonly ResumeContext _context;

        public HomeHeroController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.HomeHeroes.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddHomeHero()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddHomeHero(HomeHero homeHero)
        {
            _context.HomeHeroes.Add(homeHero);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateHomeHero(int id)
        {
            var value = _context.HomeHeroes.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateHomeHero(HomeHero homeHero)
        {
            var value = _context.HomeHeroes.Find(homeHero.HomeHeroId);
            value.NameSurname = homeHero.NameSurname;
            value.ProfileImageUrl = homeHero.ProfileImageUrl;
            value.IntroText = homeHero.IntroText;
            value.RotatingTexts = homeHero.RotatingTexts;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteHomeHero(int id)
        {
            var value = _context.HomeHeroes.Find(id);
            _context.HomeHeroes.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

