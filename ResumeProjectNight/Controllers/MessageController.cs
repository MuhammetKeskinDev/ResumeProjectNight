using Microsoft.AspNetCore.Mvc;
using ResumeProjectNight.Context;
using ResumeProjectNight.Entities;

namespace ResumeProjectNight.Controllers
{
    public class MessageController : Controller
    {
        private readonly ResumeContext _context;

        public MessageController(ResumeContext context)
        {
            _context=context;
        }

        public IActionResult MessageList()
        {
            var values = _context.Messages.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMessage(Message message)
        {
            message.SendDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message.IsRead = false;
            _context.Messages.Add(message);
            _context.SaveChanges();
            return RedirectToAction("Index", "Default");
        }

        [HttpGet]
        public IActionResult EditMessage(int id)
        {
            var value = _context.Messages.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditMessage(Message message)
        {
            var value = _context.Messages.Find(message.MessageId);
            value.NameSurname = message.NameSurname;
            value.Email = message.Email;
            value.Subject = message.Subject;
            value.MessageDetail = message.MessageDetail;
            value.IsRead = message.IsRead;
            _context.SaveChanges();
            return RedirectToAction("MessageList");
        }




    }
}
