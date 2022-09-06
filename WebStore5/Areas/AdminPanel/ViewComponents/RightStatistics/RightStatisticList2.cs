using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebStore5.Areas.AdminPanel.ViewComponents.RightStatistics
{
    public class RightStatisticList2 : ViewComponent
    {
        Context context = new Context();

        public IViewComponentResult Invoke()
        {
            ViewBag.discountproduct = context.Discounts.Count();
            ViewBag.discountlitre = context.DiscountLitres.Count();
            ViewBag.employee = context.Employees.Count();
            return View();
        }
    }
}
