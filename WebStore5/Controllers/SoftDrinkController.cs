using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebStore5.Controllers
{
    [AllowAnonymous]
    public class SoftDrinkController : Controller
    {
        private readonly ISoftDrinkService _softDrinkService;

        public SoftDrinkController(ISoftDrinkService softDrinkService)
        {
            _softDrinkService = softDrinkService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SoftDrinkDetails(int id)
        {
            ViewBag.i = id;
            var values = _softDrinkService.GetSoftDrinkID(id);
            return View(values);
        }
    }
}
