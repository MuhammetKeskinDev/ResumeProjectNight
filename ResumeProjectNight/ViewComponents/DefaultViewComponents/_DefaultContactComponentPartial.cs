using Microsoft.AspNetCore.Mvc;
using ResumeProjectNight.Context;
using ResumeProjectNight.Entities;

namespace ResumeProjectNight.ViewComponents.DefaultViewComponents
{
    public class _DefaultContactComponentPartial : ViewComponent
    {
        private readonly ResumeContext _context;

        public _DefaultContactComponentPartial(ResumeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            message.SendDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message.IsRead = false;
            _context.Messages.Add(message);
            _context.SaveChanges();
            return new JsonResult(new { success = true }); // Fixed the issue by returning a JsonResult instead of View()
        }
    }
}
