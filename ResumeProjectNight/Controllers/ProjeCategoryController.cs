using Microsoft.AspNetCore.Mvc;
using ResumeProjectNight.Context;
using ResumeProjectNight.Entities;

namespace ResumeProjectNight.Controllers
{
    public class ProjeCategoryController : Controller
    {
        private readonly ResumeContext _context;

        public ProjeCategoryController(ResumeContext context)
        {
            _context=context;
        }

        public IActionResult Index()
        {
            var values = _context.ProjectCategories.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddProjectCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProjectCategory(ProjectCategory projectCategory)
        {
            _context.ProjectCategories.Add(projectCategory);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProjectCategory(int id)
        {
            var projectCategory = _context.ProjectCategories.Find(id);
            return View(projectCategory);
        }

        [HttpPost]
        public IActionResult UpdateProjectCategory(ProjectCategory projectCategory)
        {
            var values = _context.ProjectCategories.Find(projectCategory.CategoryId);
            values.CategoryName = projectCategory.CategoryName;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProjectCategory(int id)
        {
            var projectCategory = _context.ProjectCategories.Find(id);
            _context.ProjectCategories.Remove(projectCategory);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
