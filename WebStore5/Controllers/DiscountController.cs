using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebStore5.Controllers
{
    [AllowAnonymous]
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IDiscountLitreService _discountLitreService;

        public DiscountController(IDiscountService discountService, IDiscountLitreService discountLitreService)
        {
            _discountService = discountService;
            _discountLitreService = discountLitreService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DiscountDetails(int id)
        {
            ViewBag.i = id;
            var values = _discountService.GetDiscountID(id);
            return View(values);
        }

        public IActionResult DiscountLitresDetails(int id)
        {
            ViewBag.i = id;
            var values = _discountLitreService.GetDiscountLitresID(id);
            return View(values);
        }
    }
}
