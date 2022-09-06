using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebStore5.Controllers
{
    [AllowAnonymous]
    public class FrozenSnackController : Controller
    {
        private readonly IFrozenSnacksService _frozenSnacksService;

        public FrozenSnackController(IFrozenSnacksService frozenSnacksService)
        {
            _frozenSnacksService = frozenSnacksService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FrozenSnackDetails(int id)
        {
            ViewBag.i = id;
            var values = _frozenSnacksService.GetFrozenSnackID(id);
            return View(values);
        }
    }
}
