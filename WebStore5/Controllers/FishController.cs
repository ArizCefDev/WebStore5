using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebStore5.Controllers
{
    [AllowAnonymous]
    public class FishController : Controller
    {
        private readonly IFishService _fishService;

        public FishController(IFishService fishService)
        {
            _fishService = fishService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FishDetails(int id)
        {
            ViewBag.i = id;
            var values = _fishService.GetFishID(id);
            return View(values);
        }
    }
}
