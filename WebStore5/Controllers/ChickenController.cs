using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebStore5.Controllers
{
    [AllowAnonymous]
    public class ChickenController : Controller
    {
        private readonly IChickenService _chickenService;

        public ChickenController(IChickenService chickenService)
        {
            _chickenService = chickenService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ChickenDetails(int id)
        {
            ViewBag.i = id;
            var values = _chickenService.GetChickenID(id);
            return View(values);
        }
    }
}
