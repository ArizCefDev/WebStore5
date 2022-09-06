using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebStore5.Controllers
{
    [AllowAnonymous]
    public class FruitController : Controller
    {
        private readonly IFruitService _fruitService;

        public FruitController(IFruitService fruitService)
        {
            _fruitService = fruitService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FruitDetails(int id)
        {
            ViewBag.i = id;
            var values = _fruitService.GetFruitID(id);
            return View(values);
        }
    }
}
