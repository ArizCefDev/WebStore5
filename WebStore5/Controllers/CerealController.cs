using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebStore5.Controllers
{
    [AllowAnonymous]
    public class CerealController : Controller
    {
        private readonly ICerealService _cerealService;

        public CerealController(ICerealService cerealService)
        {
            _cerealService = cerealService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CerealDetails(int id)
        {
            ViewBag.i = id;
            var values = _cerealService.GetCerealID(id);
            return View(values);
        }
    }
}
