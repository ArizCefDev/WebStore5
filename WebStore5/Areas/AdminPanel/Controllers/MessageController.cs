using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebStore5.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class MessageController : Controller
    {
        private readonly IContactService _contactService;

        public MessageController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [Route("AdminPanel/[controller]/[action]")]
        public IActionResult Index(string s)
        {
            var values = from a in _contactService.GetList() select a;
            if (!string.IsNullOrEmpty(s))
            {
                values = _contactService.ContactSearch(s);
            }
            return View(values.OrderByDescending(x => x.ID));
        }

        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            var values = _contactService.GetById(id);
            return View(values);
        }

        public IActionResult MessageDelete(int id)
        {
            var values = _contactService.GetById(id);
            _contactService.Delete(values);
            return RedirectToAction("Index", "Message");
        }
    }
}
