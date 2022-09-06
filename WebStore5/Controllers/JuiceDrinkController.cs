using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebStore5.Controllers
{
    [AllowAnonymous]
    public class JuiceDrinkController : Controller
    {
        private readonly IJuiceDrinkService _juiceDrinkService;

        public JuiceDrinkController(IJuiceDrinkService juiceDrinkService)
        {
            _juiceDrinkService = juiceDrinkService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult JuiceDrinkDetails(int id)
        {
            ViewBag.i = id;
            var values = _juiceDrinkService.GetJuiceDrinkID(id);
            return View(values);
        }
    }
}
