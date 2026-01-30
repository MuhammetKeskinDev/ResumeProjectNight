using Microsoft.AspNetCore.Mvc;
using ResumeProjectNight.Context;
using ResumeProjectNight.Entities;

namespace ResumeProjectNight.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly ResumeContext _context;

        public PortfolioController(ResumeContext context)
        {
            _context=context;
        }

        public IActionResult PortfolioList()
        {
            var values = _context.Portfolios.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult PortfolioDetail(int id)
        {
            var value = _context.Portfolios.Find(id);
            return View(value);
        }

        [HttpGet]
        public IActionResult AddPortfolio()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPortfolio(Portfolio portfolio)
        {
            _context.Portfolios.Add(portfolio);
            _context.SaveChanges();
            return RedirectToAction("PortfolioList");
        }

        [HttpGet]
        public IActionResult UpdatePortfolio(int id)
        {
            var value = _context.Portfolios.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdatePortfolio(Portfolio portfolio)
        {
            var value = _context.Portfolios.Find(portfolio.PortfolioId);
            value.ProjectTitle = portfolio.ProjectTitle;
            value.ImageUrl = portfolio.ImageUrl;
            value.Status = portfolio.Status;
            _context.SaveChanges();
            return RedirectToAction("PortfolioList");

        }

        public IActionResult DeletePortfolio(int id)
        {
            var value = _context.Portfolios.Find(id);
            _context.Portfolios.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("PortfolioList");
        }
    }
}
