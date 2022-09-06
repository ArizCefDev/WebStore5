using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebStore5.Controllers
{
    [AllowAnonymous]
    public class BeefController : Controller
    {
        private readonly IBeeftService _beeftService;

        public BeefController(IBeeftService beeftService)
        {
            _beeftService = beeftService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BeefDetails(int id)
        {
            ViewBag.i = id;
            var values = _beeftService.GetBeefID(id);
            return View(values);
        }
    }
}
