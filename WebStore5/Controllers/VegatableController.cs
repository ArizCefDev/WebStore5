using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebStore5.Controllers
{
    [AllowAnonymous]
    public class VegatableController : Controller
    {
        private readonly IVegaTableService _vegaTableService;

        public VegatableController(IVegaTableService vegaTableService)
        {
            _vegaTableService = vegaTableService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VegaDetails(int id)
        {
            ViewBag.i = id;
            var values = _vegaTableService.GetVegatablesID(id);
            return View(values);
        }
    }
}
