using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebStore5.Controllers
{
    [AllowAnonymous]
    public class SweetController : Controller
    {
        private readonly ISweetService _sweetService;

        public SweetController(ISweetService sweetService)
        {
            _sweetService = sweetService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SweetDetails(int id)
        {
            ViewBag.i = id;
            var values = _sweetService.GetSweetID(id);
            return View(values);
        }
    }
}
