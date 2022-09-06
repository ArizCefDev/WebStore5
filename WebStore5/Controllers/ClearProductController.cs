using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebStore5.Controllers
{
    [AllowAnonymous]
    public class ClearProductController : Controller
    {
        private readonly IClearProductService _clearProductService;

        public ClearProductController(IClearProductService clearProductService)
        {
            _clearProductService = clearProductService;
        }

        public IActionResult Index()
        {
            var values = _clearProductService.GetList();
            return View(values);
        }

        public IActionResult ClearProductDetails(int id)
        {
            ViewBag.i = id;
            var values = _clearProductService.GetClearProductID(id);
            return View(values);
        }
    }
}
