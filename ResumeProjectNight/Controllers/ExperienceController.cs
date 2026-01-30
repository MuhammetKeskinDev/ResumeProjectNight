using Microsoft.AspNetCore.Mvc;
using ResumeProjectNight.Context;
using ResumeProjectNight.Entities;

namespace ResumeProjectNight.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly ResumeContext _context;

        public ExperienceController(ResumeContext context)
        {
            _context=context;
        }

        public IActionResult ExperienceList()
        {
            var values = _context.Experiences.ToList();

            return View(values);
        }

        public IActionResult GetExperience(int id)
        {
            var values = _context.Experiences.Find(id);
            return View(values);
        }

        [HttpGet]
        public IActionResult AddExperience()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            _context.Experiences.Add(experience);
            _context.SaveChanges();
            return RedirectToAction("ExperienceList");
        }

        [HttpGet]
        public IActionResult UpdateExperience(int id)
        {
            var values = _context.Experiences.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateExperience(Experience experience)
        {
            var values = _context.Experiences.Find(experience.ExperienceId);
            values.Title = experience.Title;
            values.CompanyName = experience.CompanyName;
            values.Description = experience.Description;
            values.WorkPeriodDate = experience.WorkPeriodDate;
            _context.SaveChanges();
            return RedirectToAction("ExperienceList");
        }

        public IActionResult DeleteExperience(int id)
        {
            var values = _context.Experiences.Find(id);
            _context.Experiences.Remove(values);
            _context.SaveChanges();
            return RedirectToAction("ExperienceList");
        }


    }
}
