using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebStore5.ViewComponents.Discount
{
    public class DiscountList : ViewComponent
    {
        private readonly IDiscountService _discountService;

        public DiscountList(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _discountService.GetList();
            return View(values.OrderByDescending(x => x.ID));
        }
    }
}
