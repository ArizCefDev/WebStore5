using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebStore5.Controllers
{
    [AllowAnonymous]
    public class BreadController : Controller
    {
        private readonly IBreadService _breadService;

        public BreadController(IBreadService breadService)
        {
            _breadService = breadService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BreadDetails(int id)
        {
            ViewBag.i = id;
            var values = _breadService.GetBreadID(id);
            return View(values);
        }
    }
}
