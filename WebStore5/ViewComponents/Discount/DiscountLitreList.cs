using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebStore5.ViewComponents.Discount
{
    public class DiscountLitreList : ViewComponent
    {
        private readonly IDiscountLitreService _discountLitreService;

        public DiscountLitreList(IDiscountLitreService discountLitreService)
        {
            _discountLitreService = discountLitreService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _discountLitreService.GetList();
            return View(values.OrderByDescending(x => x.ID));
        }
    }
}
