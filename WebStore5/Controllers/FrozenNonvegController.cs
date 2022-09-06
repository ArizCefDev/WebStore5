using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebStore5.Controllers
{
    [AllowAnonymous]
    public class FrozenNonvegController : Controller
    {
        private readonly IFrozenNonvegService _frozenNonvegService;

        public FrozenNonvegController(IFrozenNonvegService frozenNonvegService)
        {
            _frozenNonvegService = frozenNonvegService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FrozenNonvegDetails(int id)
        {
            ViewBag.i = id;
            var values = _frozenNonvegService.GetFrozenNonvegID(id);
            return View(values);
        }
    }
}
